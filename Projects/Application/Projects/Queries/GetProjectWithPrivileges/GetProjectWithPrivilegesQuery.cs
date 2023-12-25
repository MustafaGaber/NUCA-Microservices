using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Data;
using NUCA.Projects.Domain.Entities.Boqs;

namespace NUCA.Projects.Application.Projects.Queries.GetProjectWithPrivileges
{
    public class GetProjectWithPrivilegesQuery : IGetProjectWithPrivilegesQuery
    {
        private readonly ProjectsDatabaseContext _dbContext;

        public GetProjectWithPrivilegesQuery(ProjectsDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ProjectWithPrivilegesModel> Execute(long projectId)
        {
            var project = await _dbContext.Projects
                 .Include(p => p.Company)
                 .Include(p => p.Boq)
                 .Include(p => p.Privileges)
                 .Where(p => p.Id == projectId)
                 .Select(project => new
                 {
                     project.Name,
                     BoqId = project.Boq.Id,
                     CompanyName = project.Company == null ? null : project.Company.Name,
                     Privileges = project.Privileges
                 })
                 .FirstAsync();

            List<DepartmentModel> departments =
                _dbContext.Set<BoqSection>()
                          .Where(s => s.BoqId == project.BoqId)
                          .GroupBy(s => s.DepartmentId)
                          .Select(s => new DepartmentModel() { Id = s.First().DepartmentId, Name = s.First().DepartmentName })
                          .ToList();

            return new ProjectWithPrivilegesModel
            {
                Name = project.Name,
                CompanyName = project.CompanyName,
                Departments = departments,
                Privileges = project.Privileges.Select(p =>
                    new PrivilegeModel()
                    {
                        DepartmentId = p.DepartmentId,
                        Type = p.Type,
                        UserId = p.UserId,
                    }).ToList(),
            };
        }
    }
}
