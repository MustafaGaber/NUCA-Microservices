using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Application.Statements.Queries.GetCurrentStatements;
using NUCA.Projects.Application.Statements.Queries.GetProjectStatements;
using NUCA.Projects.Data.Shared;
using NUCA.Projects.Domain.Entities.Statements;

namespace NUCA.Projects.Data.Statements
{
    public class StatementRepository : Repository<Statement, long>, IStatementRepository
    {
        public StatementRepository(ProjectsDatabaseContext database)
         : base(database) { }

        public override Task<Statement?> Get(long id)
        {
            return StatementQuery.FirstOrDefaultAsync(s => s.Id == id);
        }

        public Task<Statement?> GetLastStatement(long projectId)
        {
            return StatementQuery
                .OrderBy(s => s.Id)
                .LastOrDefaultAsync(s => s.ProjectId == projectId);
        }

        public Task<List<ProjectStatement>> GetProjectStatements(long projectId)
        {
            return database.Statements
                .Where(s => s.ProjectId == projectId)
                .Select(s => new ProjectStatement()
                {
                    Id = s.Id,
                    Index = s.Index,
                    WorksDate = s.WorksDate,
                    SubmissionDate = s.SubmissionDate,
                    Final = s.Final,
                    State = s.State,
                })
                .ToListAsync();
        }

        public Task<List<CurrentStatement>> GetCurrentStatements(long userId)
        {
            // TODO: get user statements,
            return database.Statements
                //.Where(s => s. == userId)
                .Where(s => s.State == StatementState.ExecutionState)
                .Join(database.Projects,
                s => s.ProjectId,
                p => p.Id,
                (s, p) => new CurrentStatement()
                {
                    Id = s.Id,
                    Index = s.Index,
                    ProjectName = p.Name,
                    ProjectId = p.Id,
                    WorksDate = s.WorksDate,
                    SubmissionDate = s.SubmissionDate,
                    Final = s.Final,
                    State = s.State,
                })
                .ToListAsync();
        }

        public Task<Statement?> GetStatementWithIndex(long projectId, int index)
        {
            return StatementQuery
             .FirstOrDefaultAsync(s => s.ProjectId == projectId && s.Index == index);

        }

        private IQueryable<Statement> StatementQuery => database.Statements.Include(s => s.Withholdings)
                .Include(s => s.Tables)
                .ThenInclude(t => t.Sections)
                .ThenInclude(s => s.Items)
                .ThenInclude(i => i.PercentageDetails)
                .Include(s => s.Withholdings)
                .Include(s => s.ExternalSuppliesItems)
                .AsSplitQuery();
    }
}
