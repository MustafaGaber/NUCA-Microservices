using NUCA.Projects.Application.Adjustments.Models;
using NUCA.Projects.Domain.Entities.Adjustments;

namespace NUCA.Projects.Application.Interfaces.Persistence
{
    public interface IAdjustmentRepository : IRepository<Adjustment>
    {
        public Task<bool> AdjustmentCreated(long id);
        public Task<GetAdjustmentModel?> GetAdjustmentModel(long id);
    }
}
