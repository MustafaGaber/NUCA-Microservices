using NUCA.Projects.Application.Adjustments.Models;

namespace NUCA.Projects.Application.Adjustments.Commands.UpdateWithholding
{
    public interface IUpdateWithholdingCommand
    {
        public Task<GetAdjustmentModel?> Execute(long adjustmentId, long withholdingId, EditWithholdingModel model);
    }
}
