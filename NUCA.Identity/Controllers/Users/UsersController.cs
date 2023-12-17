using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUCA.Identity.Controllers.Core;
using NUCA.Identity.Data;
using NUCA.Identity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NUCA.Identity.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        private ApplicationDbContext _context;
        private UserManager<User> _userManager;
        public UsersController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<User> users = await _context.Users
                .Include(u => u.Enrollments)
                .ThenInclude(e => e.Department)
                .ToListAsync();
            return Ok(users.Select(GetUserModel.FromUser));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserModel model)
        {
            var departmentsIds = model.Enrollments.Select(e => e.DepartmentId).ToList();
            var departments = await _context.Departments.Where(d => departmentsIds.Contains(d.Id)).ToListAsync();
            User user = new User(model.UserName, model.FullName, "1234564", new List<Enrollment>());
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                List<Enrollment> enrollments = departments
                        .Select(department => new Enrollment(user.Id, department, model.Enrollments.Find(e => e.DepartmentId == department.Id).Role)).ToList();
                _context.Enrollments.AddRange(enrollments);
                await _context.SaveChangesAsync();
                return Ok(new GetUserModel()
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Enrollments = enrollments.Select(e => new GetEnrollmentModel() { DepartmentId = e.Department.Id, DepartmentName = e.Department.Name, Role = e.Role }).ToList().ToList()
                });
            }
            else
            {
                return BadRequest();
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] UpdateUserModel model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(d => d.Id == id);
            if (user == null)
            {
                throw new InvalidOperationException();
            }
            var departmentsIds = model.Enrollments.Select(e => e.DepartmentId).ToList();
            var departments = await _context.Departments.Where(d => departmentsIds.Contains(d.Id)).ToListAsync();
            var oldEnrollments = await _context.Enrollments.Where(e => e.UserId == id).ToListAsync();
            _context.Enrollments.RemoveRange(oldEnrollments);
            List<Enrollment> enrollments = departments
                .Select(department => new Enrollment(id, department, model.Enrollments.Find(e => e.DepartmentId == department.Id).Role)).ToList();
            user.Update(model.FullName, "12345657", enrollments);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return Ok(GetUserModel.FromUser(user));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(d => d.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        [HttpGet("canDelete/{id}")]
        public async Task<IActionResult> CanDelete(string id)
        {
            //bool canDelete = await _canDeleteQuery.Execute(id);
            // todo: read can delete from projects service;
            return Ok(true);
        }
    }
}
