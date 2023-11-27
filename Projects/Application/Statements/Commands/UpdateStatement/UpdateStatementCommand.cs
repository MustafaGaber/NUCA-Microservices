using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Application.Statements.Models;
using NUCA.Projects.Domain.Entities.Statements;

namespace NUCA.Projects.Application.Statements.Commands.UpdateStatement
{
    public class UpdateStatementCommand : IUpdateStatementCommand
    {
        private readonly IStatementRepository _statementRepository;
        public UpdateStatementCommand(IStatementRepository statementRepository)
        {
            _statementRepository = statementRepository;
        }
        public async Task<StatementModel> Execute(long id, UpdateStatementModel model, long userId, bool submit)
        {
            Statement? statement = await _statementRepository.Get(id);
            if (statement == null)
            {
                throw new InvalidOperationException();
            }
            statement.Update(model, 1L);
            if (submit)
            {
                statement.Submit();
            }
            await _statementRepository.Update(statement);
            return new StatementModel(statement);
        }
    }
}
