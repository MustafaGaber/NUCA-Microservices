using NUCA.Projects.Application.Adjustments.Models;

namespace NUCA.Projects.Application.Adjustments.Commands.AddWithholding
{
    public interface IAddWithholdingCommand
    {
        public Task<AdjustmentModel?> Execute(long adjustmentId, EditWithholdingModel model);
    }
}
