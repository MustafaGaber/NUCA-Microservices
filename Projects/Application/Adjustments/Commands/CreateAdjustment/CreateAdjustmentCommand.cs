
using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Application.Interfaces.Persistence;
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

        public async Task Execute(long projectId, long statementId)
        {
            bool created = await  _dbContext.Adjustments.Where(a => a.Id == statementId).AnyAsync();
            if (created)
            {
                return;
            }
            Statement? statement = await _dbContext.Statements.Include(s => s.Withholdings).FirstOrDefaultAsync(s => s.Id == statementId) ?? throw new InvalidOperationException();
            int index = statement.Index;
            Statement? prevoiusStatement = null;
            if (index > 1)
            {
                prevoiusStatement = await _dbContext.Statements.FirstOrDefaultAsync(s => s.ProjectId == projectId && s.Index == index - 1);
                if (prevoiusStatement == null)
                {
                    throw new InvalidOperationException();
                }
            }
            Project? project = await _dbContext.Projects
                .Include(p => p.Company)
                .Include(p => p.WorkType)
                .Include(p => p.AwardType)
                .FirstOrDefaultAsync(p => p.Id == projectId) ?? throw new InvalidOperationException();
            Adjustment adjustment = Adjustment.Create(
                statementId: statementId,
                projectId: projectId,
                statementIndex: index,
                worksDate: statement.WorksDate,
                totalWorks: statement.TotalWorks,
                previousTotalWorks: prevoiusStatement == null ? 0 : prevoiusStatement.TotalWorks,
                totalSupplies: statement.TotalSupplies,
                previousTotalSupplies: prevoiusStatement == null ? 0 : prevoiusStatement.TotalSupplies,
                valueAddedTaxPercent: project.WorkType.ValueAddedTaxPercent,
                valueAddedTaxIncluded: (bool)project.ValueAddedTaxIncluded!,
                advancedPaymentPercent: (double)project.AdvancedPaymentPercentage!,
                commercialIndustrialTaxFree: project.Company!.CommercialIndustrialTaxFree,
                contractsCount: (int)project.ContractsCount!,
                contractPapersCount: (int)project.ContractPapersCount!,
                orderPrice: (double)project.Price!,
                contractPaperPrice: 2.9, // TODO :Get from settings
                withholdings: statement.Withholdings.Select(w => new AdjustmentWithholding(w.Name, w.Value, w.Type, true)).ToList()
                ) ;
            _dbContext.Adjustments.Add(adjustment);
            await _dbContext.SaveChangesAsync();
        }

    }
}
