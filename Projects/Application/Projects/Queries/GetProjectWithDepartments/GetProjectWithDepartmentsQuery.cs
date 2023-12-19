using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Data;

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
                 .Where(p => p.Id == id)
                 .Select(project => new ProjectWithDepartmentsModel
                 {
                     Id = project.Id,
                     Name = project.Name,
                     Departments = new List<string>() { },
                     CompanyName = project.Company == null ? null : project.Company.Name,
                 })
               .FirstAsync();
        }
    }
}
