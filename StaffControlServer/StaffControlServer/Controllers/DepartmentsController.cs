using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffControlServer.Context;
using StaffControlServer.Data;
using StaffControlServer.Dto;

namespace StaffControlServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DepartmentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("getFullDepartments")]
        public async Task<List<DepartmentDto>> GetFullDepartments()
        {
            var departments = await _context.Departments
                .Include(x => x.Roles).ThenInclude(x => x.UserRoles).ThenInclude(x => x.User).ToListAsync();

            return Mapper.Map<List<DepartmentDto>>(departments);
        }
    }
}
