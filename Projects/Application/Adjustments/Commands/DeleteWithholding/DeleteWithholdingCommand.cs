using NUCA.Projects.Application.Adjustments.Models;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Adjustments;

namespace NUCA.Projects.Application.Adjustments.Commands.DeleteWithholding
{
    public class DeleteWithholdingCommand: IDeleteWithholdingCommand
    {
        private readonly IAdjustmentRepository _adjustmentRepository;

        public DeleteWithholdingCommand(IAdjustmentRepository adjustmentRepository)
        {
            _adjustmentRepository = adjustmentRepository;
        }

        public async Task<AdjustmentModel?> Execute(long adjustmentId, long withholdingId)
        {
            Adjustment? adjustment = await _adjustmentRepository.Get(adjustmentId) ?? throw new InvalidOperationException();
            adjustment.RemoveWithholding(withholdingId);
            await _adjustmentRepository.Update(adjustment);
            AdjustmentModel? adjustmentModel = await _adjustmentRepository.GetAdjustmentModel(adjustmentId);
            return adjustmentModel;
        }
    }
}
