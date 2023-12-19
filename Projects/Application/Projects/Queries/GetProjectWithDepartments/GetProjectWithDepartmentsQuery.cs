using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Data;
using NUCA.Projects.Domain.Entities.Boqs;

namespace NUCA.Projects.Application.Projects.Queries.GetProjectWithDepartments
{
    public class GetProjectWithDepartmentsQuery : IGetProjectWithDepartmentsQuery
    {
        private readonly ProjectsDatabaseContext _dbContext;

        public GetProjectWithDepartmentsQuery(ProjectsDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<ProjectWithDepartmentsModel> Execute(long id)
        {

            return _dbContext.Projects
                 .Include(p => p.Company)
                 .Include(p => p.Boq)
                 .Where(p => p.Id == id)
                 .Select(project => new ProjectWithDepartmentsModel
                 {
                     Id = project.Id,
                     Name = project.Name,
                     CompanyName = project.Company == null ? null : project.Company.Name,
                     Departments = _dbContext.Set<BoqSection>()
                                  .Where(s => s.BoqId == project.Boq.Id)
                                  .Select(s => s.DepartmentId)
                                  .Distinct()
                                  .ToList()
                 }).FirstAsync();
        }
    }
}
