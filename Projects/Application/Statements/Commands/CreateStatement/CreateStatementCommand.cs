using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Boqs;
using NUCA.Projects.Domain.Entities.Statements;

namespace NUCA.Projects.Application.Statements.Commands.CreateStatement
{
    public class CreateStatementCommand : ICreateStatementCommand
    {
        private readonly IStatementRepository _statementRepository;
        private readonly IBoqRepository _boqRepository;
        public CreateStatementCommand(IStatementRepository statementRepository, IBoqRepository boqRepository)
        {
            _statementRepository = statementRepository;
            _boqRepository = boqRepository;
        }
        public async Task<long> Execute(long projectId, CreateStatementModel model)
        {
            Boq? boq = await _boqRepository.GetByProjectId(projectId) ?? throw new InvalidOperationException();
            Statement? previousStatement = await _statementRepository.GetLastStatementForProject(projectId);
            if (previousStatement != null && previousStatement.State < StatementState.Adjusted)
            {
                throw new InvalidOperationException();
            }
            Statement statement = previousStatement == null ?
            new Statement(projectId, boq, model.WorksDate, model.IsFinal)
            : new Statement(projectId, boq, model.WorksDate, model.IsFinal, previousStatement);
            Statement addedStatement = await _statementRepository.Add(statement);
            return addedStatement.Id;
        }
    }
}
