using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NUCA.Projects.Application.Projects.Queries.GetUserProjects;
using NUCA.Projects.Data;
using NUCA.Projects.Domain.Entities.Projects;
using NUCA.Projects.Domain.Entities.Statements;

namespace NUCA.Projects.Application.Projects.Queries.GetProjectsWithStatements
{
    public class GetProjectWithStatementsQuery : IGetProjectWithStatementsQuery
    {
        private readonly ProjectsDatabaseContext _dbContext;

        public GetProjectWithStatementsQuery(ProjectsDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<ProjectWithStatementsModel>> Execute()
        {
            return _dbContext.Projects
                  .Include(p => p.Company)
                  .Include(p => p.Statements)
                  .Where(p => p.Status >= ProjectStatus.Started)
                  .Select(project => new ProjectWithStatementsModel
                  {
                      Id = project.Id,
                      Name = project.Name,
                      Status = project.Status,
                      CompanyName = project.Company == null ? null : project.Company.Name,
                      StatementsCount = project.Statements.Count,
                      HasInProgressStatement = project.Statements.Any(s => s.State < StatementState.AdjustedState)
                  })
                .ToListAsync();
        }
    }
}
