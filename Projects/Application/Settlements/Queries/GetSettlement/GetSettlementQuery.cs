using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Settlements;

namespace NUCA.Projects.Application.Settlements.Queries.GetSettlement
{
    public class GetSettlementQuery : IGetSettlementQuery
    {
        private readonly ISettlementRepository _settlementRepository;

        public GetSettlementQuery(ISettlementRepository settlementRepository)
        {
            _settlementRepository = settlementRepository;
        }

        public async Task<Settlement?> Execute(long id)
        {
            var settlement = await _settlementRepository.Get(id);
            return settlement;
        }
    }
}
