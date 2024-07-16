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
using Microsoft.VisualBasic;
using StaffControlServer.Context;
using StaffControlServer.Data;
using StaffControlServer.Dto;
using StaffControlServer.Helpers;

namespace StaffControlServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;

        public CalendarsController(AppDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize]
        [HttpPost("startDay")]
        public async Task StartShift()
        {
            var user = await _userManager.Users
                .SingleOrDefaultAsync(x => x.UserName == User.ToUserInfo().Username.ToLower());

            var newShift = new Calendar()
            {
                StartDate = DateTime.UtcNow,
                UserId = user.Id,
            };

            await _context.Calendars.AddAsync(newShift);
            await _context.SaveChangesAsync();
        }

        [Authorize]
        [HttpPost("endDay")]
        public async Task EndShift()
        {
            var user = await _userManager.Users
                .SingleOrDefaultAsync(x => x.UserName == User.ToUserInfo().Username.ToLower());

            var shift = await _context.Calendars.Where(x => x.UserId == user.Id).OrderByDescending(x => x.DateCreated).FirstOrDefaultAsync();

            shift.EndDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }

        [HttpGet("getUserCalendar")]
        public async Task<List<CalendarDto>> GetCalendar(Guid userId, int year, int month)
        {
            int maxDayinMonth = DateTime.DaysInMonth(year, month);
            var startDate = new DateTime(year, month, 1, 0, 0, 0, DateTimeKind.Utc);
            var endDate = new DateTime(year, month, maxDayinMonth, 23, 59, 59, DateTimeKind.Utc);

            var shifts = await _context.Calendars.Where(x => x.UserId == userId && x.StartDate >= startDate && x.EndDate <= endDate).ToListAsync();
            return Mapper.Map<List<CalendarDto>>(shifts);
        }
    }
}
