using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Application.Statements.Models;
using NUCA.Projects.Domain.Entities.Statements;

namespace NUCA.Projects.Application.Statements.Queries.GetPrintStatement
{
    public class GetPrintStatementQuery: IGetPrintStatementQuery
    {
        private readonly IStatementRepository _statementRepository;
        private readonly IProjectRepository _projectRepository;
        public GetPrintStatementQuery(IStatementRepository statementRepository, IProjectRepository projectRepository)
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
