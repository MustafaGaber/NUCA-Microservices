using NUCA.Projects.Application.Adjustments.Models;

namespace NUCA.Projects.Application.Adjustments.Commands.Submit
{
    public interface ISubmitCommand
    {
        public Task<AdjustmentModel?> Execute(long adjustmentId);

    }
}
