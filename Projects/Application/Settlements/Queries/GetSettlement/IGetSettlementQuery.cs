
using NUCA.Projects.Domain.Entities.Settlements;

namespace NUCA.Projects.Application.Settlements.Queries.GetSettlement
{
    public interface IGetSettlementQuery
    {
        Task<Settlement?> Execute(long id);
    }
}
