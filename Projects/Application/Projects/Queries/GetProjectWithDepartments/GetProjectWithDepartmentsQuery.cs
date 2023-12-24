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
        public async Task<ProjectWithDepartmentsModel> Execute(long projectId)
        {
            var project = await _dbContext.Projects
                 .Include(p => p.Company)
                 .Include(p => p.Boq)
                 .Where(p => p.Id == projectId)
                 .Select(project => new 
                 {
                     BoqId = project.Boq.Id,
                     Name = project.Name,
                     CompanyName = project.Company == null ? null : project.Company.Name,
                     Departments = new List<string> { }
                 }).FirstAsync();
            List<DepartmentModel> departments = _dbContext.Set<BoqSection>()
                               .Where(s => s.BoqId == project.BoqId)
                               .GroupBy(s => s.DepartmentId)
                               //.Select(s => s.First())
                               .Select(s =>  new DepartmentModel() { Id = s.First().DepartmentId, Name = s.First().DepartmentName })
                               .ToList();
            return new ProjectWithDepartmentsModel
            {
                Name = project.Name,
                CompanyName = project.CompanyName,
                Departments = departments,
            };
        }
    }
}
