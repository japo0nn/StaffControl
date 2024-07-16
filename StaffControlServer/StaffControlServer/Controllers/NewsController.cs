using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffControlServer.Context;
using StaffControlServer.Data;
using StaffControlServer.Dto;
using StaffControlServer.Helpers;
using StaffControlServer.Views;

namespace StaffControlServer.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;

        public NewsController(AppDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost("create")]
        public async Task CreateNews([FromBody] NewsDto newsDto)
        {
            var user = await _userManager.Users
                .SingleOrDefaultAsync(x => x.UserName == User.ToUserInfo().Username.ToLower());

            Guid newsId = Guid.NewGuid();
            var news = new News()
            {
                Id = newsId,
                Title = newsDto.Title,
                Description = newsDto.Description,
                UserId = user.Id,
                Files = new List<FileSystem>()
            };

            foreach (var file in newsDto.Files)
            {
                string currentDirectory = Directory.GetCurrentDirectory();
                Guid fileId = Guid.NewGuid();
                string fullPath = $"{currentDirectory}/Files/NewsFiles/{newsId}";

                if (!Directory.Exists(fullPath))
                {
                    Directory.CreateDirectory(fullPath);
                }
                System.IO.File.WriteAllBytes($"{fullPath}/{fileId}.{file.FileExtension}", Convert.FromBase64String(file.FileBase64));
                
                var newFile = new FileSystem()
                {
                    Id = fileId,
                    Name = file.Name,
                    FileExtension = file.FileExtension,
                    FilePath = $"{fullPath}/{fileId}.{file.FileExtension}",
                };

                await _context.FileSystem.AddAsync(newFile);
                news.Files.Add(newFile);
            }
            await _context.News.AddAsync(news);
            await _context.SaveChangesAsync();
        }

        [HttpGet("getNewsList")]
        public async Task<IndexViewModel<NewsDto>> GetNewsList(int page = 1)
        {
            int pageSize = 10;
            IQueryable<News> news = _context.News.Include(x => x.Files).Include(x => x.User).ThenInclude(x => x.File);

            var pageView = new PageViewModel(await news.CountAsync(), page, pageSize);

            news = news
                .OrderByDescending(x => x.DateCreated)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            return new IndexViewModel<NewsDto>
            {
                PageViewModel = pageView,
                Items = await news.Select(x => Mapper.Map<News, NewsDto>(x)).ToListAsync(),
            };
        }

        [HttpGet("getPostsByUserId")]
        public async Task<IndexViewModel<NewsDto>> GetNewsByUserId(Guid userId, int page = 1)
        {
            if (page <= 0)
            {
                page = 1;
            }
            int pageSize = 10;
            IQueryable<News> news = _context.News.Where(x => x.UserId == userId)
                .Include(x => x.Files)
                .Include(x => x.User).ThenInclude(x => x.File);

            var pageView = new PageViewModel(await news.CountAsync(), page, pageSize);

            news = news
                .OrderByDescending(x => x.DateCreated)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            return new IndexViewModel<NewsDto>
            {
                PageViewModel = pageView,
                Items = await news.Select(x => Mapper.Map<News, NewsDto>(x)).ToListAsync(),
            };
        }
    }
}
