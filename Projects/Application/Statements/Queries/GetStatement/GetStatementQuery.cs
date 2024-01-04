using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Application.Statements.Models;
using NUCA.Projects.Data;
using NUCA.Projects.Domain.Entities.Projects;
using NUCA.Projects.Domain.Entities.Statements;

namespace NUCA.Projects.Application.Statements.Queries.GetStatement
{
    public class GetStatementQuery : IGetStatementQuery
    {
        private readonly IStatementRepository _statementRepository;
        private readonly IPrivilegeRepository _privilegeRepository;
        public GetStatementQuery(IStatementRepository statementRepository, IPrivilegeRepository privilegeRepository)
        {
            _statementRepository = statementRepository;
            _privilegeRepository = privilegeRepository;
        }

        public async Task<StatementModel> Execute(long id, string userId)
        {
            var statement = await _statementRepository.Get(id);
            List<Privilege> privileges = await _privilegeRepository.GetProjectPrivilegesForUser(statement.ProjectId, userId);
            if (privileges.Count() == 0)
            {
                throw new UnauthorizedAccessException();
            }
            return new StatementModel(statement ?? throw new ArgumentNullException(), privileges);
        }

    }
}
