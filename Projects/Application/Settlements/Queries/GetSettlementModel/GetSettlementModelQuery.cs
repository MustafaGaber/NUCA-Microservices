using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Application.Settlements.Models;

namespace NUCA.Projects.Application.Settlements.Queries.GetSettlement
{
    public class GetSettlementModelQuery : IGetSettlementModelQuery
    {
        private readonly ISettlementRepository _settlementRepository;

        public GetSettlementModelQuery(ISettlementRepository settlementRepository)
        {
            _settlementRepository = settlementRepository;
        }

        public async Task<GetSettlementModel?> Execute(long id)
        {
            var settlement = await _settlementRepository.GetSettlementModel(id);
            return settlement;
        }
    }
}
