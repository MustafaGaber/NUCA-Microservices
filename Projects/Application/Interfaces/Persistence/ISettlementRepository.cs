using NUCA.Projects.Application.Settlements.Models;
using NUCA.Projects.Domain.Entities.Settlements;

namespace NUCA.Projects.Application.Interfaces.Persistence
{
    public interface ISettlementRepository : IRepository<Settlement>
    {
        public Task<bool> SettlementCreated(long id);
        public Task<GetSettlementModel?> GetSettlementModel(long id);
    }
}
