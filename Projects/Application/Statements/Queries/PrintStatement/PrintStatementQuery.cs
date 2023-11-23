using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Application.Statements.Models;
using NUCA.Projects.Domain.Entities.Statements;

namespace NUCA.Projects.Application.Statements.Queries.PrintStatement
{
    public class PrintStatementQuery: IPrintStatementQuery
    {
        private readonly IStatementRepository _statementRepository;
        private readonly IProjectRepository _projectRepository;
        public PrintStatementQuery(IStatementRepository statementRepository, IProjectRepository projectRepository)
        {
            _statementRepository = statementRepository;
            _projectRepository = projectRepository;
        }

        public async Task<PrintStatementModel> Execute(long id)
        {
            var statement = await _statementRepository.Get(id);
            var project = await _projectRepository.Get(statement.ProjectId);
            return new PrintStatementModel() { Statement = statement, Project = project };
        }
    }
}
