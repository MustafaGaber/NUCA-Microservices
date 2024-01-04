using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Application.Statements.Models;
using NUCA.Projects.Domain.Entities.Projects;
using NUCA.Projects.Domain.Entities.Statements;
using NUCA.Projects.Shared.Extensions;
using System.Security.Claims;

namespace NUCA.Projects.Application.Statements.Commands.TechnicalOfficeSubmit
{
    public class TechnicalOfficeSubmitCommand: ITechnicalOfficeSubmitCommand
    {
        private readonly IStatementRepository _statementRepository;
        private readonly IPrivilegeRepository _privilegeRepository;

        public TechnicalOfficeSubmitCommand(IStatementRepository statementRepository, IPrivilegeRepository privilegeRepository)
        {
            _statementRepository = statementRepository;
            _privilegeRepository = privilegeRepository;
        }
        public async Task<StatementModel> Execute(long id, TechnicalOfficeSubmitModel model, ClaimsPrincipal user)
        {
            string userId = user.Id() ?? throw new ArgumentNullException(nameof(user));
            Statement? statement = await _statementRepository.Get(id) ?? throw new InvalidOperationException();
            List<Privilege> privileges = await _privilegeRepository.GetProjectPrivilegesForUser(statement.ProjectId, userId);
            if (!(privileges.Any(p => p.Type == PrivilegeType.TechnicalOffice || p.Type == PrivilegeType.TechnicalOfficeManager)))
            {
                throw new UnauthorizedAccessException();
            }
            if (model.Approved)
            {
                 statement.TechnicalOfficeApprove(userId);
            }
            else
            {
                statement.TechnicalOfficeDisapprove(userId, model.Message);
            }
            await _statementRepository.Update(statement);
            return new StatementModel(statement, privileges);
        }
    }
}

