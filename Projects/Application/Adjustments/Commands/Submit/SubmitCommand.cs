using NUCA.Projects.Application.Adjustments.Models;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Adjustments;

namespace NUCA.Projects.Application.Adjustments.Commands.Submit
{
    public class SubmitCommand : ISubmitCommand
    {
        private readonly IAdjustmentRepository _adjustmentRepository;

        public SubmitCommand(IAdjustmentRepository adjustmentRepository)
        {
            _adjustmentRepository = adjustmentRepository;
        }
        public async Task<AdjustmentModel?> Execute(long adjustmentId)
        {
            Adjustment? adjustment = await _adjustmentRepository.Get(adjustmentId);
            if (adjustment == null)
            {
                throw new InvalidOperationException();
            }
            adjustment.Submit();
            await _adjustmentRepository.Update(adjustment);
            AdjustmentModel? adjustmentModel = await _adjustmentRepository.GetAdjustmentModel(adjustmentId);
            return adjustmentModel;
        }
    }
}
