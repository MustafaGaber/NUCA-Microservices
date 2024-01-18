
using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Data;
using NUCA.Projects.Domain.Entities.Adjustments;
using NUCA.Projects.Domain.Entities.Projects;
using NUCA.Projects.Domain.Entities.Statements;

namespace NUCA.Projects.Application.Adjustments.Commands.CreateAdjustment
{
    public class CreateAdjustmentCommand : ICreateAdjustmentCommand
    {
        private readonly ProjectsDatabaseContext _dbContext;

        public CreateAdjustmentCommand(ProjectsDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Execute(long projectId, long statementId, CreateAdjustmentModel model)
        {
            bool created = await _dbContext.Adjustments.Where(a => a.Id == statementId).AnyAsync();
            if (created) return;

            Statement? statement = await _dbContext.Statements.Include(s => s.Withholdings).FirstOrDefaultAsync(s => s.Id == statementId) ?? throw new InvalidOperationException();
            int index = statement.Index;

            Statement? prevoiusStatement = null;
            if (index > 1)
            {
                prevoiusStatement = await _dbContext.Statements.FirstOrDefaultAsync(s => s.ProjectId == projectId && s.Index == index - 1);
                if (prevoiusStatement == null && model.Empty)
                {
                    throw new InvalidOperationException();
                }
            }
            double previousTotalWorks = index == 1 ? 0 : prevoiusStatement != null ?
                prevoiusStatement.TotalWorks : (double)model.PreviousTotalWorks!;

            double previousTotalSupplies = index == 1 ? 0 : prevoiusStatement != null ?
               prevoiusStatement.TotalSupplies : (double)model.PreviousTotalSupplies!;

            Project? project = await _dbContext.Projects
                .Include(p => p.Company)
                .Include(p => p.WorkType)
                .Include(p => p.AwardType)
                .FirstOrDefaultAsync(p => p.Id == projectId) ?? throw new InvalidOperationException();

            List<double> advancedPaymentDeductions = await _dbContext
                 .AdvancedPaymentDeductions
                 .Where(a => a.ProjectId == projectId)
                 .Select(a => a.Amount)
                 .ToListAsync();
            double totalAdvancedPaymentDeductions = advancedPaymentDeductions.Sum();
            Adjustment adjustment = Adjustment.Create(
                statementId: statementId,
                projectId: projectId,
                statementIndex: index,
                worksDate: statement.WorksDate,
                totalWorks: statement.TotalWorks,
                previousTotalWorks: previousTotalWorks,
                totalSupplies: statement.TotalSupplies,
                previousTotalSupplies: previousTotalSupplies,
                valueAddedTaxPercent: project.WorkType.ValueAddedTaxPercent,
                valueAddedTaxIncluded: (bool)project.ValueAddedTaxIncluded!,
                advancedPaymentPercent: (double)project.AdvancedPaymentPercentage!,
                totalAdvancedPaymentDeductions: totalAdvancedPaymentDeductions,
                commercialIndustrialTaxFree: project.Company!.CommercialIndustrialTaxFree,
                contractsCount: (int)project.ContractsCount!,
                contractPapersCount: (int)project.ContractPapersCount!,
                orderPrice: (double)project.Price!,
                contractPaperPrice: 2.9, // TODO :Get from settings
                withholdings: statement.Withholdings.Select(w => new AdjustmentWithholding(w.Name, w.Value, w.Type, true)).ToList()
            );
            statement.SetStateAdjusting();
            _dbContext.Adjustments.Add(adjustment);
            await _dbContext.SaveChangesAsync();
        }
    }
}
