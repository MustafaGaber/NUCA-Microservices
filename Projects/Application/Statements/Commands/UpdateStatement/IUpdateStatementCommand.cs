using NUCA.Projects.Application.Statements.Models;
using NUCA.Projects.Domain.Entities.Statements;

namespace NUCA.Projects.Application.Statements.Commands.UpdateStatement
{
    public interface IUpdateStatementCommand
    {
        Task<Statement> Execute(long id, UpdateStatementModel model, long userId);
    }
}
