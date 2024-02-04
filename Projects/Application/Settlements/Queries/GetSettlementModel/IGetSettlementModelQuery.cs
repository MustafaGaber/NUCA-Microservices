
using NUCA.Projects.Application.Settlements.Models;

namespace NUCA.Projects.Application.Settlements.Queries.GetSettlement
{
    public interface IGetSettlementModelQuery
    {
        Task<GetSettlementModel?> Execute(long id);
    }
}
