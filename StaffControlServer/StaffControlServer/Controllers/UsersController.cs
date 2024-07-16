
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using MailKit;
using Newtonsoft.Json;
using StaffControlServer.Context;
using StaffControlServer.Data;
using StaffControlServer.Dto;
using StaffControlServer.Helpers;
using StaffControlServer.Views;
using MailKit.Net.Smtp;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace StaffControlServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;

        public UsersController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context;
        }

        [Authorize]
        [HttpGet("isAdmin")]
        public async Task<IActionResult> CheckAdminUser()
        {
            var user = await _userManager.Users
                .SingleOrDefaultAsync(x => x.UserName == User.ToUserInfo().Username.ToLower());
            var inRole = await _userManager.IsInRoleAsync(user, "Системный администратор");

            if (!inRole) return BadRequest();

            return Ok();
        }

        [HttpPost("addUser")]
        public async Task<IActionResult> AddNewUser([FromBody] UserDto userDto)
        {
            var admin = await _context.Users
                .SingleOrDefaultAsync(x => x.UserName == User.ToUserInfo().Username.ToLower());

            var inRole = await _userManager.IsInRoleAsync(admin, "Системный администратор");
            if (!inRole) return BadRequest();

            var existingEmail = await _userManager.FindByEmailAsync(userDto.Email);
            if (existingEmail != null)
            {
                Response.ContentType = "application/json";
                Response.StatusCode = 409;
                await Response.WriteAsync("Email existing");
                return BadRequest();
            }

            var user = new User()
            {
                Email = userDto.Email,
                UserName = userDto.Username.ToLower(),
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                ParentUserId = userDto.ParentUserId,
            };
            await _userManager.CreateAsync(user, "Aa123456");
            foreach (var userRole in userDto.Roles)
            {
                var role = await _roleManager.FindByIdAsync(userRole.Id.ToString());
                await _userManager.AddToRoleAsync(user, role.Name);
            }
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("login")]
        public async Task Login([FromBody] LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username.ToLower());
            if (user == null)
            {
                Response.StatusCode = 401;
                Response.ContentType = "application/json";
                await Response.WriteAsync("Пользователь с таким Username не найден");
                return;
            }
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (!result.Succeeded)
            {
                Response.StatusCode = 401;
                Response.ContentType = "application/json";
                await Response.WriteAsync("Неверный пароль");
                return;
            }

            await Token(model.Username);
        }

        [Authorize]
        [HttpGet("current")]
        public async Task<UserDto> GetUserInfo()
        {
            var user = await _userManager.Users
                .Include(x => x.ParentUser)
                .Include(x => x.UserRoles).ThenInclude(x => x.Role).ThenInclude(x => x.ParentRole)
                .Include(x => x.UserRoles).ThenInclude(x => x.Role).ThenInclude(x => x.Department)
                .Include(x => x.ToDoList)
                .Include(x => x.File)
                .SingleOrDefaultAsync(x => x.UserName == User.ToUserInfo().Username.ToLower());

            user.ToDoList = user.ToDoList.Where(x => x.ResponsibleId == user.Id).ToList();

            var roles = await _userManager.GetRolesAsync(user);
            return Mapper.Map<User, UserDto>(user);
        }

        [Authorize]
        [HttpPut("edit")]
        public async Task EditUserInfo([FromBody] SetUserDataViewModel userDto)
        {
            var user = await _userManager.Users
                .SingleOrDefaultAsync(x => x.UserName == User.ToUserInfo().Username.ToLower());

            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;

            await _context.SaveChangesAsync();
        }

        [Authorize]
        [HttpPut("changeImage")]
        public async Task ChangeUserImage([FromBody] FileSystemDto fileSystemDto)
        {
            var user = await _userManager.Users
                .Include(x => x.File)
                .SingleOrDefaultAsync(x => x.UserName == User.ToUserInfo().Username.ToLower());

            if (user.File != null)
            {
                System.IO.File.Delete(user.File.FilePath);
                _context.FileSystem.Remove(user.File);
            }

            string currentDirectory = Directory.GetCurrentDirectory();
            Guid fileId = Guid.NewGuid();
            string fullPath = $"{currentDirectory}\\Files\\ProfileImages\\{user.Id}";
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }
            System.IO.File.WriteAllBytes($"{fullPath}\\profilePhoto_{fileId}.{fileSystemDto.FileExtension}", Convert.FromBase64String(fileSystemDto.FileBase64));

            var newFile = new FileSystem()
            {
                Id = fileId,
                Name = fileSystemDto.Name,
                FileExtension = fileSystemDto.FileExtension,
                FilePath = $"{fullPath}\\profilePhoto_{fileId}.{fileSystemDto.FileExtension}",
            };

            await _context.FileSystem.AddAsync(newFile);
            user.FileId = fileId;
            await _context.SaveChangesAsync();
        }

        [Authorize]
        [HttpDelete("deleteUserImage")]
        public async Task DeleteUserImage()
        {
            var user = await _userManager.Users
                .Include(x => x.File)
                .SingleOrDefaultAsync(x => x.UserName == User.ToUserInfo().Username.ToLower());

            if (user.File != null)
            {
                System.IO.File.Delete(user.File.FilePath);
                user.FileId = null;
                _context.FileSystem.Remove(user.File);
            }

            await _context.SaveChangesAsync();
        }

        [Authorize]
        [HttpGet("getUsersList")]
        public async Task<IndexViewModel<UserDto>> GetUsersList(int page = 1)
        {
            int pageSize = 20;
            IQueryable<User> users = _userManager.Users
                .Include(x => x.UserRoles).ThenInclude(x => x.Role)
                .Include(x => x.File);

            var pageView = new PageViewModel(await users.CountAsync(), page, pageSize);

            users = users
                .OrderBy(x => x.LastName)
                .OrderBy(x => x.FirstName)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            return new IndexViewModel<UserDto>
            {
                PageViewModel = pageView,
                Items = await users.Select(x => Mapper.Map<User, UserDto>(x)).ToListAsync(),
            };
        }

        [Authorize]
        [HttpPost("changePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordViewModel viewModel)
        {
            var user = await _userManager.Users
                .SingleOrDefaultAsync(x => x.UserName == User.ToUserInfo().Username.ToLower());

            var changePassword = await _userManager.ChangePasswordAsync(user, viewModel.OldPassword, viewModel.NewPassword);
            
            if (changePassword.Succeeded)
            {
                return Ok();
            }

            return BadRequest();
        }

        [Authorize]
        [HttpGet("check2FA")]
        public async Task<IActionResult> Check2FAEnabled()
        {
            var user = await _userManager.Users
                .SingleOrDefaultAsync(x => x.UserName == User.ToUserInfo().Username.ToLower());

            if (user.TwoFactorEnabled) return Ok();

            return BadRequest();
        }

        [Authorize]
        [HttpGet("enableOrDisable2FA")]
        public async Task<IActionResult> EnableOrDisable2FA(string code)
        {
            var user = await _userManager.Users
                .SingleOrDefaultAsync(x => x.UserName == User.ToUserInfo().Username.ToLower());

            if (user.TwoFactorCode != code)
            {
                return BadRequest();
            }
            user.TwoFactorEnabled = !user.TwoFactorEnabled;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [Authorize]
        [HttpGet("sendCode")]
        public async Task EnableTwoFactorAuthentication()
        {
            var user = await _userManager.Users
                .SingleOrDefaultAsync(x => x.UserName == User.ToUserInfo().Username.ToLower());

            var random = new Random();
            var code = random.Next(1000, 10000);

            user.TwoFactorCode = code.ToString();
            await _context.SaveChangesAsync();
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("StaffController CodeBot", "yedilbayev12@yandex.ru"));
            message.To.Add(new MailboxAddress(user.UserName, user.Email));
            message.Subject = "StaffController Code";
            message.Body = new TextPart("plain")
            {
                Text = code.ToString()
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.yandex.ru", 465, true);

                client.Authenticate("yedilbayev12", "eaedaqsnjrnvybzg");

                client.Send(message);
                client.Disconnect(true);
            }
        }

        [Authorize]
        [HttpGet("verify")]
        public async Task<IActionResult> Verify(string code)
        {
            var user = await _userManager.Users
                .SingleOrDefaultAsync(x => x.UserName == User.ToUserInfo().Username.ToLower());

            if (user.TwoFactorCode != code)
            {
                return BadRequest();
            }

            return Ok();
        }

        private async Task Token(string email)
        {
            var identity = GetIdentity(email);
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name,
            };

            Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }


        private ClaimsIdentity GetIdentity(string login)
        {
            var claims = new List<Claim>
            {
                new(ClaimsIdentity.DefaultNameClaimType, login),
            };

            ClaimsIdentity claimIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);

            return claimIdentity;
        }
    }
}
