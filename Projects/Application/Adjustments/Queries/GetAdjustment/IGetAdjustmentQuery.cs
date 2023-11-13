
using NUCA.Projects.Application.Adjustments.Models;

namespace NUCA.Projects.Application.Adjustments.Queries.GetAdjustment
{
    public interface IGetAdjustmentQuery
    {
        Task<AdjustmentModel?> Execute(long id);
    }
}
