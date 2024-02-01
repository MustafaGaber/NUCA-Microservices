using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Application.Projects.Queries.GetUserProjects;
using NUCA.Projects.Data;
using NUCA.Projects.Shared.Constants;
using NUCA.Projects.Shared.Extensions;
using System.Security.Claims;

namespace NUCA.Projects.Application.Projects.Queries.GetProjects
{
    public class GetUserProjectsQuery : IGetUserProjectsQuery
    {
        private readonly ProjectsDatabaseContext _dbContext;

        public GetUserProjectsQuery(ProjectsDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<UserProject>> Execute(ClaimsPrincipal user)
        {
            if (user.Id() == null) throw new UnauthorizedAccessException();

            var query = _dbContext.Projects
                .Include(p => p.Company)
                .Include(p => p.Privileges)
                .AsQueryable();

            var permissions = user.Permissions();
            if (!(permissions.Contains(Permissions.Projects) ||
                  permissions.Contains(Permissions.Revision) ||
                  permissions.Contains(Permissions.Accounting)))
            {
                query = query.Where(p => p.Privileges.Any(privilege => privilege.UserId == user.Id()));
            }

            return query.Select(project =>
                new UserProject
                {
                    Id = project.Id,
                    Name = project.Name,
                    Status = project.Status,
                    CompanyName = project.Company == null ? null : project.Company.Name,
                    Privileges = project.Privileges
                        .Select(p => new PrivilegeModel() { Type = p.Type, DepartmentId = p.DepartmentId })
                        .ToList(),
                    Approved = project.Approved,
                }).ToListAsync();
        }
    }
}


