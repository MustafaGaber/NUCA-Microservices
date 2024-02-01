
using NUCA.Projects.Domain.Entities.Adjustments;

namespace NUCA.Projects.Application.Adjustments.Queries.GetAdjustment
{
    public interface IGetAdjustmentQuery
    {
        Task<Adjustment?> Execute(long id);
    }
}
