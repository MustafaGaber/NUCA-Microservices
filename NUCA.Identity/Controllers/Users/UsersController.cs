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

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<GetUserModel> users = await _context.Set<User>().
                Select(d => new GetUserModel() { Id = d.Id, FullName = d.FullName }).ToListAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserModel model)
        {
            User user = new User(model.FullName, "1234564");
            User item = _context.Set<User>().Add(user).Entity;
            await _context.SaveChangesAsync();
            return Ok(item.Id);
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
