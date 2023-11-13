using NUCA.Projects.Application.Statements.Queries.GetCurrentStatements;
using NUCA.Projects.Application.Statements.Queries.GetProjectStatements;
using NUCA.Projects.Domain.Entities.Statements;

namespace NUCA.Projects.Application.Interfaces.Persistence
{
    public interface IStatementRepository : IRepository<Statement, long>
    {
        public Task<Statement?> GetLastStatement(long projectId);
        public Task<Statement?> GetStatementWithIndex(long projectId, int index);
        public Task<List<ProjectStatement>> GetProjectStatements(long projectId);
        public Task<List<CurrentStatement>> GetCurrentStatements(long userId);
    }
}
