using NUCA.Projects.Data;

namespace NUCA.Projects.Application.Adjustments.Commands.UpdateAdjustment
{
    public class UpdateAdjustmentCommand
    {
        private readonly ProjectsDatabaseContext _dbContext;

        public UpdateAdjustmentCommand(ProjectsDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Execute(long projectId, long adjustmentId, UpdateAdjustmentModel model)
        {
            /*Adjustment adjustment = await _dbContext.Adjustments
                .Include(a => a.Project)
                .ThenInclude(p => p.Company)
                .Include(a => a.Project)
                .ThenInclude(p => p.WorkType)
                .FirstAsync();

            Statement? statement = await _dbContext.Statements
                .Include(s => s.Withholdings)
                .FirstOrDefaultAsync(s => s.Id == adjustmentId) ?? throw new InvalidOperationException();

            bool firstInProject = statement.Index == 1;

            Statement? prevoiusStatement = null;
            bool firstInDatabase = true;
            if (!firstInProject)
            {
                prevoiusStatement = await _dbContext.Statements.FirstOrDefaultAsync(s => s.ProjectId == projectId && s.Index == statement.Index - 1);
                firstInDatabase = prevoiusStatement == null;
               /* if (firstInDatabase && model.Empty)
                {
                    throw new InvalidOperationException();
                }
        }
        double previousTotalWorks = firstInProject ? 0 : firstInDatabase ?
                  (double)model.PreviousTotalWorks! :
                  prevoiusStatement!.TotalWorks;

        double previousTotalSupplies = firstInProject ? 0 : firstInDatabase ?
                 (double)model.PreviousTotalSupplies! :
                 prevoiusStatement!.TotalSupplies;

        Project project = await _dbContext.Projects
            .Include(p => p.Company)
            .Include(p => p.WorkType)
            .Include(p => p.AwardType)
            .FirstOrDefaultAsync(p => p.Id == projectId) ?? throw new InvalidOperationException();
        bool hasAdvancePayment = project.AdvancePaymentPercentage > 0;
        double totalAdvancePaymentDeductions = (firstInProject || !hasAdvancePayment) ? 0 :
            firstInDatabase ? (double)model.TotalAdvancePaymentDeductions! :
            (await _dbContext
                 .AdvancePaymentDeductions
                 .Where(a => a.ProjectId == projectId)
                 .Select(a => a.Amount)
                 .ToListAsync()).Sum();

        Adjustment adjustment = Adjustment.Create(
            statementId: adjustmentId,
            project: project,
            statementIndex: statement.Index,
            worksDate: statement.WorksDate,
            totalWorks: statement.TotalWorks,
            previousTotalWorks: previousTotalWorks,
            totalSupplies: statement.TotalSupplies,
            previousTotalSupplies: previousTotalSupplies,
            totalAdvancePaymentDeductions: totalAdvancePaymentDeductions,
            contractPaperPrice: 2.9, // TODO :Get from settings
            withholdings: statement.Withholdings.Select(w => new AdjustmentWithholding(w.Name, w.Value, w.Type, true)).ToList()
        );
        statement.SetStateAdjusting();
            if (hasAdvancePayment && firstInDatabase && !firstInProject && totalAdvancePaymentDeductions > 0)
            {
                _dbContext.AdvancePaymentDeductions.Add(
                    new AdvancePaymentDeduction
                    {
                        ProjectId = projectId,
                        Amount = totalAdvancePaymentDeductions,
                        AdjustmentId = null,
                    });
            }
            _dbContext.Adjustments.Add(adjustment);
            await _dbContext.SaveChangesAsync(); */
        }
    }
}
