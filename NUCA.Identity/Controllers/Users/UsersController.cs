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
    // [Authorize(LocalApi.PolicyName)]
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
            var user = User;
            List<User> users = await _userManager.Users.ToListAsync();
            return Ok(users.Select(GetUserModel.FromUser));
        }

        [HttpGet("Roles")]
        public IActionResult Roles()
        {
            return Ok(Role.AllRoles.Select(r => new RoleModel() { Name = r.Name, PublicName = r.PublicName }).ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserModel model)
        {
            var departmentsIds = model.Enrollments.Select(e => e.DepartmentId).ToList();
            var departments = await _context.Departments.Where(d => departmentsIds.Contains(d.DepartmentId)).ToListAsync();
            List<UserGroup> groups = await _context.Set<UserGroup>().Where(g => model.Groups.Contains(g.Id)).ToListAsync();
            User user = new User(model.UserName, model.FullName, model.NationalId, model.PhoneNumber, new List<Enrollment> { }, groups);
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded) return BadRequest();

            List<Enrollment> enrollments = model.Enrollments
              .Select(enrollment => new Enrollment(user.Id, departments.Find(d => d.DepartmentId == enrollment.DepartmentId), enrollment.Job)).ToList();

            _context.Enrollments.AddRange(enrollments);
            await _context.SaveChangesAsync();

            await _userManager.AddToRolesAsync(user, model.Roles);
            return Ok(new GetUserModel()
            {
                Id = user.Id,
                FullName = user.FullName,
                NationalId = user.NationalId,
                PhoneNumber = user.PhoneNumber,
                Enrollments = enrollments.Select(e => new GetEnrollmentModel { DepartmentId = e.DepartmentId.ToString(), DepartmentName = e.Department.Name, Job = e.Job }).ToList().ToList(),
                Roles = user.Roles.Select(r => new RoleModel { Name = r.Role.Name, PublicName = r.Role.PublicName }).ToList(),
                Groups = user.Groups.Select(g => new GroupModel { Id = g.Id, Name = g.Name, }).ToList()
            });
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] UpdateUserModel model)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(d => d.Id == id) ?? throw new InvalidOperationException();
            var departmentsIds = model.Enrollments.Select(e => e.DepartmentId).ToList();
            var departments = await _context.Departments.Where(d => departmentsIds.Contains(d.DepartmentId)).ToListAsync();
            var oldEnrollments = await _context.Enrollments
                .Where(e => e.UserId == id).ToListAsync();
            _context.Enrollments.RemoveRange(oldEnrollments);
            List<Enrollment> enrollments = model.Enrollments
                 .Select(enrollment => new Enrollment(user.Id, departments.Find(d => d.DepartmentId == enrollment.DepartmentId), enrollment.Job)).ToList();
            List<UserGroup> groups = await _context.Set<UserGroup>().Where(g => model.Groups.Contains(g.Id)).ToListAsync();

            user.Update(model.FullName, model.NationalId, model.PhoneNumber, enrollments, groups); // todo
            await _userManager.UpdateAsync(user);
            await _userManager.RemoveFromRolesAsync(user, user.Roles.Select(r => r.Role.Name).ToList());
            await _userManager.AddToRolesAsync(user, model.Roles);
            await _context.SaveChangesAsync();
            await _userManager.UpdateSecurityStampAsync(await _userManager.FindByIdAsync(id));
            return Ok(GetUserModel.FromUser(user));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
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
