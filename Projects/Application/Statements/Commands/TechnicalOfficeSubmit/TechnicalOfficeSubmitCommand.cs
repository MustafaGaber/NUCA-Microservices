using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Statements;
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
        public async Task Execute(long id, TechnicalOfficeSubmitModel model, ClaimsPrincipal user)
        {
            Statement? statement = await _statementRepository.GetMainStatementData(id);
            if (statement == null)
            {
                throw new InvalidOperationException();
            }
           // statement.TechnicalOfficeApprove();
            await _statementRepository.Update(statement);
        }
    }
}

