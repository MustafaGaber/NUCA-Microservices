using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Data;
using NUCA.Projects.Domain.Entities.Statements;

namespace NUCA.Projects.Application.Statements.Queries.GetStatement
{
    public class GetStatementQuery : IGetStatementQuery
    {
        private readonly IStatementRepository _statementRepository;
        public GetStatementQuery(IStatementRepository statementRepository)
        {
            _statementRepository = statementRepository;
        }

        public async Task<Statement> Execute(long id)
        {
            var statement = await _statementRepository.Get(id);
            return statement;
        }

    }
}
