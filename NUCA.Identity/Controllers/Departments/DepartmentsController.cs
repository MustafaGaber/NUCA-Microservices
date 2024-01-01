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
using static IdentityServer4.IdentityServerConstants;

namespace NUCA.Identity.Controllers.Departments
{
   // [Authorize(LocalApi.PolicyName)]
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
            List<GetDepartmentModel> departments = await _context.Set<Department>()
                .Include(d => d.Permissions)
                .Select(d =>  GetDepartmentModel.FromDepartment(d))
                .ToListAsync();
            return Ok(departments);
        }

        [HttpGet("Execution")]
        public async Task<IActionResult> GetExecutionDepartments()
        {
            List<GetDepartmentModel> departments = await _context.Set<Department>()
                .Include(d => d.Permissions)
                .Where(d => d.Permissions.Any( p => p.Id == DepartmentPermission.Execution.Id))
                .Select(d => GetDepartmentModel.FromDepartment(d))
                .ToListAsync();
            return Ok(departments);
        }

        [HttpGet("Permissions")]
        public IActionResult GetPermissions()
        {
            return Ok(DepartmentPermission.AllPermissions.Select(role => new PermissionModel()
            {
                Id = role.Id,
                Name = role.Name,
            }).ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDepartmentModel model)
        {
            var permissions = model.Permissions.Select(DepartmentPermission.GetById).ToList();
            foreach (var permission in permissions)
            {
                _context.Attach(permission);
            }
            Department department = new Department(model.Name, permissions);
            Department item = _context.Set<Department>().Add(department).Entity;
            await _context.SaveChangesAsync();
            return Ok(item.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] CreateDepartmentModel model)
        {
            var department = await _context.Set<Department>().Include(d => d.Permissions).FirstOrDefaultAsync(d => d.Id == id);
            if (department == null)
            {
                throw new InvalidOperationException();
            }
            var permissions = model.Permissions.Select(DepartmentPermission.GetById).ToList();
            foreach (var permission in permissions.Where(permission => !department.Permissions.Any(p => p.Id == permission.Id)))
            {
                _context.Attach(permission);
            }
            department.Update(model.Name, permissions);
            _context.Set<Department>().Update(department);
            await _context.SaveChangesAsync();
            return Ok();
        }

        /* [HttpDelete("{id}")]
         public async Task<IActionResult> Delete(int id)
         {
             var department = await _context.Set<Department>().FirstOrDefaultAsync(d => d.DepartmentId == id);
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
