using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StaffControlServer.Context;
using StaffControlServer.Data;
using StaffControlServer.Dto;
using StaffControlServer.Views;

namespace StaffControlServer.Services
{
    public class TaskFilterService
    {
        private readonly AppDbContext _dbContext;
        public TaskFilterService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IndexViewModel<ToDoDto>> GetFilteredTasks(TaskFilterViewModel model, Guid userId, bool isAuthor, int page = 1)
        {
            int pageSize = 10;
            if (page <= 0)
            {
                page = 1;
            }

            IQueryable<ToDo> todoes = _dbContext.ToDoes
                .Include(x => x.Author).ThenInclude(x => x.File)
                .Include(x => x.Responsible).ThenInclude(x => x.File);

            if (model.StartDate != null)
            {
                todoes = todoes.Where(x => x.StartDate >= model.StartDate);
            }

            if (model.EndDate != null)
            {
                todoes = todoes.Where(x => x.EndDate <= model.EndDate);
            }

            if (model.ToDoStatus != null)
            {
                todoes = todoes.Where(x => x.Status == model.ToDoStatus);
            }

            if (isAuthor)
            {
                todoes = todoes.Where(x => x.AuthorId == userId);
            }
            else
            {
                todoes = todoes.Where(x => x.ResponsibleId == userId);
            }

            PageViewModel pageView = new PageViewModel(await todoes.CountAsync(), page, pageSize);

            todoes = todoes
                .OrderByDescending(x => x.DateCreated)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            return new IndexViewModel<ToDoDto>
            {
                PageViewModel = pageView,
                Items = await todoes.Select(x => Mapper.Map<ToDo, ToDoDto>(x)).ToListAsync(),
            };
        }
    }
}
