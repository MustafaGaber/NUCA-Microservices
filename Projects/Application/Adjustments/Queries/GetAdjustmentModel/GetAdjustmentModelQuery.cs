using NUCA.Projects.Application.Adjustments.Models;
using NUCA.Projects.Application.Interfaces.Persistence;

namespace NUCA.Projects.Application.Adjustments.Queries.GetAdjustment
{
    public class GetAdjustmentModelQuery : IGetAdjustmentModelQuery
    {
        private readonly IAdjustmentRepository _adjustmentRepository;

        public GetAdjustmentModelQuery(IAdjustmentRepository adjustmentRepository)
        {
            _adjustmentRepository = adjustmentRepository;
        }

        public async Task<GetAdjustmentModel?> Execute(long id)
        {
            var adjustment = await _adjustmentRepository.GetAdjustmentModel(id);
            return adjustment;
        }
    }
}
