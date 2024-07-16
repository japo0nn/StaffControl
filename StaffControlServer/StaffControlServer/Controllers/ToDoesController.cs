using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffControlServer.Context;
using StaffControlServer.Data;
using StaffControlServer.Dto;
using StaffControlServer.Enum;
using StaffControlServer.Helpers;
using StaffControlServer.Services;
using StaffControlServer.Views;

namespace StaffControlServer.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ToDoesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly TaskFilterService _taskFilterService;
        public ToDoesController(AppDbContext context, TaskFilterService taskFilterService)
        {
            _context = context;
            _taskFilterService = taskFilterService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTask([FromBody] ToDoDto toDoDto)
        {
            var author = await _context.Users
                .SingleOrDefaultAsync(x => x.UserName == User.ToUserInfo().Username.ToLower());

            var newTodo = new ToDo()
            {
                Name = toDoDto.Name,
                Description = toDoDto.Description,
                AuthorId = author.Id,
                ResponsibleId = toDoDto.ResponsibleId,
                EndDate = toDoDto.EndDate,
            };

            await _context.ToDoes.AddAsync(newTodo);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateTask([FromBody] ToDoDto toDoDto)
        {
            var todo = await _context.ToDoes.SingleOrDefaultAsync(x => x.Id == toDoDto.Id);

            if (todo.Status == Enum.ToDoStatus.InProcess || todo.Status == Enum.ToDoStatus.Awaiting) {
                todo.Name = toDoDto.Name;
                todo.Description = toDoDto.Description;
                todo.EndDate = toDoDto.EndDate;
                todo.CompleteDate = toDoDto.CompleteDate;
                todo.ResponsibleId = toDoDto.ResponsibleId;

                await _context.SaveChangesAsync();

                return Ok();
            }

            return BadRequest();
        }

        [HttpPut("updateStatus")]
        public async Task UpdateTaskStatus(Guid todoId, ToDoStatus status)
        {
            var todo = await _context.ToDoes.SingleOrDefaultAsync(x => x.Id == todoId);
            todo.Status = status;

            await _context.SaveChangesAsync();
        }

        [HttpGet("getTaskById")]
        public async Task<ToDoDto> GetTaskById(Guid todoId)
        {
            var todo = await _context.ToDoes
                .Include(x => x.Author).ThenInclude(x => x.File)
                .Include(x => x.Responsible).ThenInclude(x => x.File)
                .SingleOrDefaultAsync(x => x.Id == todoId);

            return Mapper.Map<ToDoDto>(todo);
        }

        [HttpGet("getTasksByUserId")]
        public async Task<IndexViewModel<ToDoDto>> GetUserTasks(Guid userId, int page = 1)
        {
            int pageSize = 10;
            IQueryable<ToDo> toDos = _context.ToDoes
                .Include(x => x.Author).ThenInclude(x => x.File)
                .Include(x => x.Responsible).ThenInclude(x => x.File)
                .Where(x => (x.ResponsibleId == userId || x.AuthorId == userId) 
                    && (x.Status != Enum.ToDoStatus.Rejected || x.Status != Enum.ToDoStatus.Completed));

            var pageView = new PageViewModel(await toDos.CountAsync(), page, pageSize);

            toDos = toDos
                .OrderByDescending(x => x.DateCreated)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            return new IndexViewModel<ToDoDto>()
            {
                PageViewModel = pageView,
                Items = await toDos.Select(x => Mapper.Map<ToDo, ToDoDto>(x)).ToListAsync(),
            };
        }

        [HttpPost("getResponsibleTasks")]
        public async Task<IndexViewModel<ToDoDto>> GetResponsibleTasks([FromBody] TaskFilterViewModel model, int page = 1)
        {
            var user = await _context.Users
                .SingleOrDefaultAsync(x => x.UserName == User.ToUserInfo().Username.ToLower());

            var indexViewModel = await _taskFilterService.GetFilteredTasks(model, user.Id, false, page);

            return indexViewModel;
        }

        [HttpPost("getAuthorTasks")]
        public async Task<IndexViewModel<ToDoDto>> GetAuthorTasks([FromBody] TaskFilterViewModel model, int page = 1)
        {
            var user = await _context.Users
                .SingleOrDefaultAsync(x => x.UserName == User.ToUserInfo().Username.ToLower());

            var indexViewModel = await _taskFilterService.GetFilteredTasks(model, user.Id, true, page);

            return indexViewModel;
        }
    }
}
