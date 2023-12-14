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

namespace NUCA.Identity.Controllers.Departments
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : BaseController
    {
        private ApplicationDbContext _context;

        public DepartmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<GetDepartmentModel> departments = await _context.Set<Department>().
                Select(d => new GetDepartmentModel() { Id = d.Id, Name = d.Name}).ToListAsync();
            return Ok(departments);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDepartmentModel model)
        {
            Department department = new Department(model.Name, new IdentityRole("department_role"));
            Department item = _context.Set<Department>().Add(department).Entity;
            await _context.SaveChangesAsync();
            return Ok(item.Id);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateDepartmentModel model)
        {
            var department = await _context.Set<Department>().FirstOrDefaultAsync(d => d.Id == id);
            if (department == null)
            {
                throw new InvalidOperationException();
            }
            department.Update(model.Name);
            _context.Set<Department>().Update(department);
            await _context.SaveChangesAsync();
            return Ok();
        }

       /* [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var department = await _context.Set<Department>().FirstOrDefaultAsync(d => d.Id == id);
            if (department != null)
            {
                _context.Set<Department>().Remove(department);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        [HttpGet("canDelete/{id}")]
        public async Task<IActionResult> CanDelete(int id)
        {
            bool canDelete = await _canDeleteQuery.Execute(id);
            return Ok(canDelete);
        }*/
    }
}
