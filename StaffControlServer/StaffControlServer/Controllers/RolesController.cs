using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffControlServer.Context;
using StaffControlServer.Data;
using StaffControlServer.Dto;

namespace StaffControlServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public RolesController(AppDbContext context, RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet("getRoles")]
        public async Task<List<RoleDto>> GetRoles()
        {
            var roles = await _context.Roles
                .Include(x => x.Department)
                .Include(x => x.UserRoles).ThenInclude(x => x.User).ThenInclude(x => x.File)
                .Where(x => x.Name != "Системный администратор")
                .ToListAsync();

            return Mapper.Map<List<RoleDto>>(roles);
        }

        [HttpGet("getUsersInRole")]
        public async Task<List<UserDto>> GetUsersInRole(string roleName)
        {
            var users = await _userManager.GetUsersInRoleAsync(roleName);

            return Mapper.Map<List<UserDto>>(users);
        }
    }
}
