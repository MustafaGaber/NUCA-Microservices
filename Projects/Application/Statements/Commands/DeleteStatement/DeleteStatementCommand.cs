
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Statements;

namespace NUCA.Projects.Application.Statements.Commands.DeleteStatement
{
    public class DeleteStatementCommand : IDeleteStatementCommand
    {
        private readonly IStatementRepository _statementRepository;
        public DeleteStatementCommand(IStatementRepository statementRepository, IBoqRepository boqRepository)
        {
            _statementRepository = statementRepository;
        }
        public async Task Execute(long id)
        {
            Statement? statement = await _statementRepository.Get(id) ?? throw new InvalidOperationException();
            if (statement.State != StatementState.Execution)
            {
                throw new InvalidOperationException();
            }
            await _statementRepository.Delete(id);
        }
    }
}
