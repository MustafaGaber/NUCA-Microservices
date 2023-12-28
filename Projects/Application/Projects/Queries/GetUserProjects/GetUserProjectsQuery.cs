using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Application.Projects.Queries.GetUserProjects;
using NUCA.Projects.Data;

namespace NUCA.Projects.Application.Projects.Queries.GetProjects
{
    public class GetUserProjectsQuery : IGetUserProjectsQuery
    {
        private readonly ProjectsDatabaseContext _dbContext;

        public GetUserProjectsQuery(ProjectsDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<UserProject>> Execute(string userId)
        {
            return _dbContext.Projects
                .Include(p => p.Company)
                .Include(p => p.Privileges)
                .Where(p => p.Privileges.Any(privilege => privilege.UserId == userId))
                .Select(project =>
                new UserProject
                {
                    Id = project.Id,
                    Name = project.Name,
                    Status = project.Status,
                    CompanyName = project.Company == null ? null : project.Company.Name,
                    Privileges = project.Privileges
                        .Select(p => new PrivilegeModel() { Type = p.Type, DepartmentId = p.DepartmentId})
                        .ToList()
                }).ToListAsync();
        }
    }
}


