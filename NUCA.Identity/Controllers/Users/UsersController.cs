using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUCA.Identity.Controllers.Core;
using NUCA.Identity.Data;
using NUCA.Identity.Models;
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
            List<User> users = await _context.Set<User>()
                .Include(u => u.Departments)
                .ToListAsync();

            return Ok(users.Select(u => new GetUserModel()
            {
                Id = u.Id,
                FullName = u.FullName,
                Departments = u.Departments
                      .Select(d => new DepartmentModel() { Id = d.Id, Name = d.Name }).ToList()
            }));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserModel model)
        {
            var departments = await _context.Set<Department>().Where(d => model.DepartmentsIds.Contains(d.Id)).ToListAsync();
            User user = new User(model.UserName, model.FullName, "1234564", departments);
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return Ok(new GetUserModel()
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Departments = departments.Select(d => new DepartmentModel() { Id = d.Id, Name = d.Name }).ToList()
                });
            }
            else
            {
                return BadRequest();
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] CreateUserModel model)
        {
            var user = await _context.Set<User>().FirstOrDefaultAsync(d => d.Id == id);
            if (user == null)
            {
                throw new InvalidOperationException();
            }
            user.Update(model.FullName, "12345657");
            _context.Set<User>().Update(user);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _context.Set<User>().FirstOrDefaultAsync(d => d.Id == id);
            if (user != null)
            {
                _context.Set<User>().Remove(user);
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
