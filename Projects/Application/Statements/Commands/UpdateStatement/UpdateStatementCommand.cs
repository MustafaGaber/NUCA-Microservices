using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Projects;
using NUCA.Projects.Domain.Entities.Statements;

namespace NUCA.Projects.Application.Statements.Commands.UpdateStatement
{
    public class UpdateStatementCommand : IUpdateStatementCommand
    {
        private readonly IStatementRepository _statementRepository;
        private readonly IPrivilegeRepository _privilegeRepository;
        public UpdateStatementCommand(IStatementRepository statementRepository, IPrivilegeRepository privilegeRepository)
        {
            _statementRepository = statementRepository;
            _privilegeRepository = privilegeRepository;
        }
        public async Task<Statement> Execute(long id, UpdateStatementModel model, string userId)
        {
            Statement? statement = await _statementRepository.Get(id) ?? throw new InvalidOperationException();
            if (statement.State != StatementState.Execution && statement.State != StatementState.ReturnedToExecution)
            {
                throw new InvalidOperationException();
            }
            List<Privilege> privileges = await _privilegeRepository.GetProjectPrivilegesForUser(statement.ProjectId, userId);
            if (!(privileges.Any(p => p.Type == PrivilegeType.Execution)))
            {
                throw new UnauthorizedAccessException();
            }
            var updatedDepartmentsIds = model.Items.Select(item =>
                   statement.Tables.First(t => t.Id == item.TableId)
                            .Sections.First(s => s.Id == item.SectionId)
                            .DepartmentId).Distinct();
            if (!updatedDepartmentsIds.All(id => privileges.Any(p => p.DepartmentId == id))) {
                throw new UnauthorizedAccessException();
            }
            if (!model.ExternalSuppliesItems.All(item => privileges.Any(p => p.DepartmentId == item.DepartmentId)))
            {
                throw new UnauthorizedAccessException();
            }
            statement.Update(model);
            if (model.Submit)
            {
                foreach (var privilege in privileges.Where(p => p.Type == PrivilegeType.Execution && p.DepartmentId != null))
                {
                    statement.ExecutionSubmit(privilege.DepartmentId!, userId);
                }
            }
            await _statementRepository.Update(statement);
            return statement;
        }
    }
}
