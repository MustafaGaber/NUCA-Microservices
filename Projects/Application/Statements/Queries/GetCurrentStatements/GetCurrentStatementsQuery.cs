using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Application.Statements.Queries.GetCurrentStatements;

namespace NUCA.Projects.Application.Statements.Queries.GetUserStatements
{
    public class GetCurrentStatementsQuery : IGetCurrentStatementsQuery
    {

        private readonly IStatementRepository _statementRepository;
        public GetCurrentStatementsQuery(IStatementRepository statementRepository)
        {
            _statementRepository = statementRepository;
        }
        public async Task<List<CurrentStatement>> Execute(long userId)
        {
            var statements = await _statementRepository.GetCurrentStatements(userId);
            return statements;
        }
    }
}
