using NUCA.Projects.Application.Statements.Models;
using NUCA.Projects.Domain.Entities.Statements;

namespace NUCA.Projects.Application.Statements.Commands.UpdateStatement
{
    public interface IUpdateStatementCommand
    {
        Task<StatementModel> Execute(long id, UpdateStatementModel model, long userId, bool submit);
    }
}
