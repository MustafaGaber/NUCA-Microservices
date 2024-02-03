using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Application.Projects.Models;
using NUCA.Projects.Domain.Entities.Projects;
using NUCA.Projects.Domain.Entities.Settings;
using System.Security.Claims;

namespace NUCA.Projects.Application.Projects.Commands.UpdateLedgers
{
    public class UpdateLedgersCommand : IUpdateLedgersCommand
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ILedgerRepository _ledgerRepository;

        public UpdateLedgersCommand(IProjectRepository projectRepository, ILedgerRepository ledgerRepository)
        {
            _projectRepository = projectRepository;
            _ledgerRepository = ledgerRepository;
        }

        public async Task<GetProjectLedgersModel> Execute(long projectId, UpdateLedgersModel model, ClaimsPrincipal user)
        {
            Project project = await _projectRepository.Get(projectId) ?? throw new ArgumentNullException("Project not found");
            Ledger fromLedger = await _ledgerRepository.Get(model.FromLedgerId) ?? throw new ArgumentNullException("Ledger not found");
            Ledger toLedger = await _ledgerRepository.Get(model.ToLedgerId) ?? throw new ArgumentNullException("Ledger not found");
            Ledger advancePaymentLedger = await _ledgerRepository.Get(model.AdvancePaymentLedgerId) ?? throw new ArgumentNullException("Ledger not found");

            project.UpdateLedgers(
                fromLedger: fromLedger,
                toLedger: toLedger,
                advancePaymentLedger: advancePaymentLedger);

            await _projectRepository.SaveChangesAsync();
            return new GetProjectLedgersModel
            {
                Id = projectId,
                Name = project.Name,
                FromLedger = new LedgerModel
                {
                    Id = project.FromLedger!.Id,
                    Name = project.FromLedger!.Name,
                    Code = project.FromLedger!.Code,
                    ParentId = project.FromLedger!.ParentId,
                    ParentFullPath = project.FromLedger!.ParentFullPath
                },
                ToLedger = new LedgerModel
                {
                    Id = project.ToLedger!.Id,
                    Name = project.ToLedger!.Name,
                    Code = project.ToLedger!.Code,
                    ParentId = project.ToLedger!.ParentId,
                    ParentFullPath = project.ToLedger!.ParentFullPath
                },
                AdvancePaymentLedger = new LedgerModel
                {
                    Id = project.AdvancePaymentLedger!.Id,
                    Name = project.AdvancePaymentLedger!.Name,
                    Code = project.AdvancePaymentLedger!.Code,
                    ParentId = project.AdvancePaymentLedger!.ParentId,
                    ParentFullPath = project.AdvancePaymentLedger!.ParentFullPath
                }
            };
        }
    }
}
