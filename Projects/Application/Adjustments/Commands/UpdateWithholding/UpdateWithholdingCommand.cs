using NUCA.Projects.Application.Adjustments.Models;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Adjustments;

namespace NUCA.Projects.Application.Adjustments.Commands.UpdateWithholding
{
    public class UpdateWithholdingCommand : IUpdateWithholdingCommand
    {
        private readonly IAdjustmentRepository _adjustmentRepository;

        public UpdateWithholdingCommand(IAdjustmentRepository adjustmentRepository)
        {
            _adjustmentRepository = adjustmentRepository;
        }

        public async Task<GetAdjustmentModel?> Execute(long adjustmentId, long withholdingId, EditWithholdingModel model)
        {
            Adjustment? adjustment = await _adjustmentRepository.Get(adjustmentId) ?? throw new InvalidOperationException();
            AdjustmentWithholding withholding = new AdjustmentWithholding(model.Name, model.Value, model.Type, false);
            adjustment.UpdateWithholding(withholdingId, withholding);
            await _adjustmentRepository.Update(adjustment);
            GetAdjustmentModel? adjustmentModel = await _adjustmentRepository.GetAdjustmentModel(adjustmentId);
            return adjustmentModel;
        }
    }
}
