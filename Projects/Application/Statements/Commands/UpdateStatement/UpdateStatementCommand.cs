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
        public async Task<Statement> Execute(long id, UpdateStatementModel model, long userId)
        {
            Statement? statement = await _statementRepository.Get(id);
            if (statement == null)
            {
                throw new InvalidOperationException();
            }
            statement.Update(model);
            if (model.Submit)
            {
                statement.Submit();
            }
            await _statementRepository.Update(statement);
            return statement;
        }
    }
}
