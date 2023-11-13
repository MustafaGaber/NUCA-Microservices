using NUCA.Projects.Application.Adjustments.Models;

namespace NUCA.Projects.Application.Adjustments.Commands.DeleteWithholding
{
    public interface IDeleteWithholdingCommand
    {
        public Task<AdjustmentModel?> Execute(long adjustmentId, long withholdingId);

    }
}
