
using NUCA.Projects.Application.Adjustments.Models;

namespace NUCA.Projects.Application.Adjustments.Queries.GetAdjustment
{
    public interface IGetAdjustmentModelQuery
    {
        Task<GetAdjustmentModel?> Execute(long id);
    }
}
