using NUCA.Projects.Application.Interfaces.Persistence;
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
        public async Task<Statement> Execute(long id, UpdateStatementModel model, long userId, bool submit)
        {
            Statement? statement = await _statementRepository.Get(id);
            if (statement == null)
            {
                throw new InvalidOperationException();
            }
            // Todo: move logic to Statment Entity
            model.Items.ForEach(update => statement.UpdateItem(
                update.TableId,
                update.SectionId,
                update.ItemId,
                new StatementItemUpdates(
                    update.TotalQuantity,
                    update.Percentage,
                    // update.Percentages.Select(u => new StatementItemPercentage(u.Quantity, u.Percentage, u.Notes)).ToList(),
                    update.Notes,
                    userId
                    )
                ));
            statement.UpdateWithholdings(model.Withholdings);
            if (submit)
            {
                statement.Submit();
            }
            await _statementRepository.Update(statement);
            return statement;
        }
    }
}
