using NUCA.Projects.Application.Adjustments.Models;

namespace NUCA.Projects.Application.Adjustments.Commands.UpdateAdjustment
{
    public interface IUpdateAdjustmentCommand
    {
        Task<GetAdjustmentModel> Execute(long adjustmentId, UpdateAdjustmentModel model);

    }
}
