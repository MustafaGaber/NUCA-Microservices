using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Application.Adjustments.Models;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Data;
using NUCA.Projects.Domain.Entities.Adjustments;

namespace NUCA.Projects.Application.Adjustments.Commands.UpdateAdjustment
{
    public class UpdateAdjustmentCommand : IUpdateAdjustmentCommand
    {
        private readonly ProjectsDatabaseContext _dbContext;
        private readonly IAdjustmentRepository _adjustmentRepository;

        public UpdateAdjustmentCommand(ProjectsDatabaseContext dbContext, IAdjustmentRepository adjustmentRepository)
        {
            _dbContext = dbContext;
            _adjustmentRepository = adjustmentRepository;
        }

        public async Task<GetAdjustmentModel> Execute(long adjustmentId, UpdateAdjustmentModel model)
        {
            Adjustment adjustment = await _dbContext
                .Adjustments
                .Include(a => a.Withholdings)
                .Include(a => a.Statement)
                .Include(a => a.Project).ThenInclude(p => p.Company)
                .Include(a => a.Project).ThenInclude(p => p.WorkType)
                .Include(a => a.Project).ThenInclude(p => p.AdvancePaymentDeductions)
                .FirstOrDefaultAsync(s => s.Id == adjustmentId) ?? throw new InvalidOperationException();

            if (adjustment.Statement.Index == 1)
            {
                throw new InvalidOperationException();
            }

            if (adjustment.Project.AdvancePaymentPercentage == 0 && model.TotalAdvancePaymentDeductions > 0)
            {
                throw new InvalidOperationException();
            }

            bool hasPrevoiusStatement = await _dbContext.Statements.AnyAsync(s => s.ProjectId == adjustment.ProjectId && s.Index == adjustment.Statement.Index - 1);

            if (hasPrevoiusStatement)
            {
                throw new InvalidOperationException();
            }


            adjustment.Update(
                previousTotalWorks: model.PreviousTotalWorks,
                previousTotalSupplies: model.PreviousTotalSupplies,
                totalAdvancePaymentDeductions: model.TotalAdvancePaymentDeductions,
                contractPaperPrice: 2.9
            );

            _dbContext.RemoveRange(adjustment.Project.AdvancePaymentDeductions);

            if (model.TotalAdvancePaymentDeductions > 0)
            {
                _dbContext.AdvancePaymentDeductions.Add(
                    new AdvancePaymentDeduction
                    {
                        ProjectId = adjustment.ProjectId,
                        Amount = model.TotalAdvancePaymentDeductions,
                        AdjustmentId = null,
                    });
            }
            await _dbContext.SaveChangesAsync();
            return GetAdjustmentModel.Create(adjustment, true);
        }
    }
}
