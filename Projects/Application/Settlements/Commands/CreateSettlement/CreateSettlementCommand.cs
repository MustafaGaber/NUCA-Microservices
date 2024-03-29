﻿
using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Data;
using NUCA.Projects.Domain.Entities.Projects;
using NUCA.Projects.Domain.Entities.Settlements;
using NUCA.Projects.Domain.Entities.Statements;

namespace NUCA.Projects.Application.Settlements.Commands.CreateSettlement
{
    public class CreateSettlementCommand : ICreateSettlementCommand
    {
        private readonly ProjectsDatabaseContext _dbContext;

        public CreateSettlementCommand(ProjectsDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Execute(long projectId, long statementId, CreateSettlementModel? model)
        {
            bool created = await _dbContext.Settlements
                .Where(a => a.Id == statementId)
                .AnyAsync();
            if (created) return;
            Statement? statement = await _dbContext.Statements.Include(s => s.Withholdings).FirstOrDefaultAsync(s => s.Id == statementId) ?? throw new InvalidOperationException();
            bool firstInProject = statement.Index == 1;
            Statement? prevoiusStatement = null;
            bool firstInDatabase = true;
            if (!firstInProject)
            {
                prevoiusStatement = await _dbContext.Statements.FirstOrDefaultAsync(s => s.ProjectId == projectId && s.Index == statement.Index - 1);
                firstInDatabase = prevoiusStatement == null;
                if (firstInDatabase && model == null)
                {
                    throw new InvalidOperationException();
                }
            }
            double previousTotalWorks = firstInProject ? 0 : firstInDatabase ?
                      (double)model!.PreviousTotalWorks :
                      prevoiusStatement!.TotalWorks;

            double previousTotalSupplies = firstInProject ? 0 : firstInDatabase ?
                     (double)model!.PreviousTotalSupplies :
                     prevoiusStatement!.TotalSupplies;

            Project project = await _dbContext.Projects
                .Include(p => p.Company)
                .Include(p => p.WorkType)
                .FirstOrDefaultAsync(p => p.Id == projectId) ?? throw new InvalidOperationException();

            bool hasAdvancePayment = project.AdvancePaymentPercentage > 0;
            double totalAdvancePaymentDeductions = (firstInProject || !hasAdvancePayment) ? 0 :
                firstInDatabase ? (double)model!.TotalAdvancePaymentDeductions :
                (await _dbContext
                     .AdvancePaymentDeductions
                     .Where(a => a.ProjectId == projectId)
                     .Select(a => a.Amount)
                     .ToListAsync()).Sum();

            Settlement settlement = new Settlement(
                statement: statement,
                project: project,
                previousTotalWorks: previousTotalWorks,
                previousTotalSupplies: previousTotalSupplies,
                totalAdvancePaymentDeductions: totalAdvancePaymentDeductions,
                contractPaperPrice: 2.9 // TODO :Get from settings
            );
            if (hasAdvancePayment && firstInDatabase && !firstInProject && totalAdvancePaymentDeductions > 0)
            {
                _dbContext.AdvancePaymentDeductions.Add(
                    new AdvancePaymentDeduction
                    {
                        ProjectId = projectId,
                        Amount = totalAdvancePaymentDeductions,
                        SettlementId = null,
                    });
            }
            _dbContext.Settlements.Add(settlement);
            statement.SetStateAdjusting();
            await _dbContext.SaveChangesAsync();
        }
    }
}
