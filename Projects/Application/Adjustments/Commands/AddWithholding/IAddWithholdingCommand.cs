using NUCA.Projects.Application.Adjustments.Models;

namespace NUCA.Projects.Application.Adjustments.Commands.AddWithholding
{
    public interface IAddWithholdingCommand
    {
        public Task<GetAdjustmentModel?> Execute(long adjustmentId, EditWithholdingModel model);
    }
}
