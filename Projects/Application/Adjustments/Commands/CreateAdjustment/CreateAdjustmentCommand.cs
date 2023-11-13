
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

        public CreateAdjustmentCommand(ProjectsDatabaseContext dbContext, IAdjustmentRepository adjustmentRepository, IStatementRepository statementRepository, IProjectRepository projectRepository)
        {
            _dbContext = dbContext;
        }

        public async Task<long> Execute(long projectId, long statementId)
        {
            bool created = await  _dbContext.Adjustments.Where(a => a.Id == statementId).AnyAsync();
            if (created)
            {
                throw new InvalidOperationException();
            }
            Statement? statement = await _dbContext.Statements.Include(s => s.Withholdings).FirstOrDefaultAsync(s => s.Id == statementId);
            if (statement == null)
            {
                throw new InvalidOperationException();
            }
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
                .Include(p => p.Type)
                .Include(p => p.AwardType)
                .FirstOrDefaultAsync(p => p.Id == projectId);
            if (project == null)
            {
                throw new InvalidOperationException();
            }
            Adjustment adjustment = Adjustment.Create(
                statementId: statementId,
                projectId: projectId,
                statementIndex: index,
                worksDate: statement.WorksDate,
                totalWorks: statement.TotalWorks,
                previousTotalWorks: prevoiusStatement == null ? 0 : prevoiusStatement.TotalWorks,
                totalSupplies: statement.TotalSupplies,
                previousTotalSupplies: prevoiusStatement == null ? 0 : prevoiusStatement.TotalSupplies,
                valueAddedTaxPercent: project.Type.ValueAddedTaxPercent,
                valueAddedTaxIncluded: (bool)project.ValueAddedTaxIncluded!,
                advancedPaymentPercent: (double)project.AdvancedPaymentPercentage!,
                commercialIndustrialTaxFree: project.Company!.CommercialIndustrialTaxFree,
                totalContractPapers: (int)project.TotalContractPapers!,
                orderPrice: (double)project.Price!,
                contractPaperPrice: 2.9, // TODO :Get from settings
                withholdings: statement.Withholdings.Select(w => new AdjustmentWithholding(w.Name, w.Value, w.Type, true)).ToList()
                ) ;
            _dbContext.Adjustments.Add(adjustment);
            statement.SetAdjustmentCreated();
            await _dbContext.SaveChangesAsync();
            return adjustment.Id;
        }

    }
}
