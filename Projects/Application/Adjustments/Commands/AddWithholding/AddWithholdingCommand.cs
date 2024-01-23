using NUCA.Projects.Application.Adjustments.Models;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Adjustments;

namespace NUCA.Projects.Application.Adjustments.Commands.AddWithholding
{
    public class AddWithholdingCommand : IAddWithholdingCommand
    {
        private readonly IAdjustmentRepository _adjustmentRepository;

        public AddWithholdingCommand(IAdjustmentRepository adjustmentRepository)
        {
            _adjustmentRepository = adjustmentRepository;
        }

        public async Task<GetAdjustmentModel?> Execute(long adjustmentId, EditWithholdingModel model)
        {
            Adjustment? adjustment = await _adjustmentRepository.Get(adjustmentId) ?? throw new InvalidOperationException();
            AdjustmentWithholding withholding = new AdjustmentWithholding(model.Name, model.Value, model.Type, false);
            adjustment.AddWithholding(withholding);
            await _adjustmentRepository.Update(adjustment);
            GetAdjustmentModel? adjustmentModel = await _adjustmentRepository.GetAdjustmentModel(adjustmentId);
            return adjustmentModel;
        }
    }
}
