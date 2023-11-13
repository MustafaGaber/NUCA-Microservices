using NUCA.Projects.Application.Interfaces.Persistence;

namespace NUCA.Projects.Application.Statements.Queries.GetProjectStatements
{
    public class GetProjectStatementsQuery : IGetProjectStatementsQuery
    {
        private readonly IStatementRepository _statementRepository;
        public GetProjectStatementsQuery(IStatementRepository statementRepository)
        {
            _statementRepository = statementRepository;
        }
        public async Task<List<ProjectStatement>> Execute(long projectId)
        {
            var statements = await _statementRepository.GetProjectStatements(projectId);
            return statements;
        }
    }
}
