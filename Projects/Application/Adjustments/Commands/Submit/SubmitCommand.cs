using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Application.Adjustments.Models;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Data;
using NUCA.Projects.Domain.Entities.Adjustments;
using NUCA.Projects.Domain.Entities.Statements;

namespace NUCA.Projects.Application.Adjustments.Commands.Submit
{
    public class SubmitCommand : ISubmitCommand
    {
        private readonly ProjectsDatabaseContext _dbContext;
        private readonly IAdjustmentRepository _adjustmentRepository;
        public SubmitCommand(ProjectsDatabaseContext dbContext, IAdjustmentRepository adjustmentRepository)
        {
            _dbContext = dbContext;
            _adjustmentRepository = adjustmentRepository;
        }

        public async Task<AdjustmentModel?> Execute(long adjustmentId)
        {
            Adjustment? adjustment = await _dbContext.Adjustments.FirstOrDefaultAsync(s => s.Id == adjustmentId);
            Statement? statement = await _dbContext.Statements.Include(s => s.Withholdings).FirstOrDefaultAsync(s => s.Id == adjustmentId);
            if (adjustment == null || statement == null)
            {
                throw new InvalidOperationException();
            }
            adjustment.Submit();
            statement.SetAdjusted();
            await _dbContext.SaveChangesAsync();
            AdjustmentModel? adjustmentModel = await _adjustmentRepository.GetAdjustmentModel(adjustmentId);
            return adjustmentModel;
        }
    }
}
