using NUCA.Projects.Application.Settlements.Models;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Settlements;

namespace NUCA.Projects.Application.Settlements.Commands.DeleteWithholding
{
    public class DeleteWithholdingCommand: IDeleteWithholdingCommand
    {
        private readonly ISettlementRepository _settlementRepository;

        public DeleteWithholdingCommand(ISettlementRepository settlementRepository)
        {
            _settlementRepository = settlementRepository;
        }

        public async Task<GetSettlementModel?> Execute(long settlementId, long withholdingId)
        {
            Settlement? settlement = await _settlementRepository.Get(settlementId) ?? throw new InvalidOperationException();
            settlement.RemoveWithholding(withholdingId);
            await _settlementRepository.Update(settlement);
            GetSettlementModel? settlementModel = await _settlementRepository.GetSettlementModel(settlementId);
            return settlementModel;
        }
    }
}
