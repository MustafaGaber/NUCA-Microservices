using NUCA.Projects.Application.Statements.Queries.GetCurrentStatements;
using NUCA.Projects.Application.Statements.Queries.GetProjectStatements;
using NUCA.Projects.Data.Shared;
using NUCA.Projects.Domain.Entities.Statements;

namespace NUCA.Projects.Application.Interfaces.Persistence
{
    public interface IStatementRepository : IRepository<Statement>
    {
        public Task<Statement?> GetMainStatementData(long id);
        public Task<Statement?> GetLastStatementForProject(long projectId);
        public Task<Statement?> GetStatementWithIndex(long projectId, int index);
        public Task<List<ProjectStatement>> GetProjectStatements(long projectId);
        public Task<List<CurrentStatement>> GetCurrentStatements(long userId);
    }
}
