using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Application.Settlements.Models;
using NUCA.Projects.Data;
using NUCA.Projects.Domain.Entities.Settlements;

namespace NUCA.Projects.Application.Settlements.Commands.UpdateSettlement
{
    public class UpdateSettlementCommand : IUpdateSettlementCommand
    {
        private readonly ProjectsDatabaseContext _dbContext;
        private readonly ISettlementRepository _settlementRepository;

        public UpdateSettlementCommand(ProjectsDatabaseContext dbContext, ISettlementRepository settlementRepository)
        {
            _dbContext = dbContext;
            _settlementRepository = settlementRepository;
        }

        public async Task<GetSettlementModel> Execute(long settlementId, UpdateSettlementModel model)
        {
            Settlement settlement = await _dbContext
                .Settlements
                .Include(a => a.Withholdings)
                .Include(a => a.Statement)
                .Include(a => a.Project).ThenInclude(p => p.Company)
                .Include(a => a.Project).ThenInclude(p => p.WorkType)
                .Include(a => a.Project).ThenInclude(p => p.AdvancePaymentDeductions)
                .FirstOrDefaultAsync(s => s.Id == settlementId) ?? throw new InvalidOperationException();

            if (settlement.Statement.Index == 1)
            {
                throw new InvalidOperationException();
            }

            if (settlement.Project.AdvancePaymentPercentage == 0 && model.TotalAdvancePaymentDeductions > 0)
            {
                throw new InvalidOperationException();
            }

            bool hasPrevoiusStatement = await _dbContext.Statements.AnyAsync(s => s.ProjectId == settlement.ProjectId && s.Index == settlement.Statement.Index - 1);

            if (hasPrevoiusStatement)
            {
                throw new InvalidOperationException();
            }


            settlement.Update(
                previousTotalWorks: model.PreviousTotalWorks,
                previousTotalSupplies: model.PreviousTotalSupplies,
                totalAdvancePaymentDeductions: model.TotalAdvancePaymentDeductions,
                contractPaperPrice: 2.9
            );

            _dbContext.RemoveRange(settlement.Project.AdvancePaymentDeductions);

            if (model.TotalAdvancePaymentDeductions > 0)
            {
                _dbContext.AdvancePaymentDeductions.Add(
                    new AdvancePaymentDeduction
                    {
                        ProjectId = settlement.ProjectId,
                        Amount = model.TotalAdvancePaymentDeductions,
                        SettlementId = null,
                    });
            }
            await _dbContext.SaveChangesAsync();
            return GetSettlementModel.Create(settlement, true);
        }
    }
}
