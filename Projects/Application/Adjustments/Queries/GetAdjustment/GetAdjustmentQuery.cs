using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Adjustments;

namespace NUCA.Projects.Application.Adjustments.Queries.GetAdjustment
{
    public class GetAdjustmentQuery : IGetAdjustmentQuery
    {
        private readonly IAdjustmentRepository _adjustmentRepository;

        public GetAdjustmentQuery(IAdjustmentRepository adjustmentRepository)
        {
            _adjustmentRepository = adjustmentRepository;
        }

        public async Task<Adjustment?> Execute(long id)
        {
            var adjustment = await _adjustmentRepository.Get(id);
            return adjustment;
        }
    }
}
