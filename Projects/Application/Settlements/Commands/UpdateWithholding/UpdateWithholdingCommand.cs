using NUCA.Projects.Application.Settlements.Models;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Settlements;

namespace NUCA.Projects.Application.Settlements.Commands.UpdateWithholding
{
    public class UpdateWithholdingCommand : IUpdateWithholdingCommand
    {
        private readonly ISettlementRepository _settlementRepository;

        public UpdateWithholdingCommand(ISettlementRepository settlementRepository)
        {
            _settlementRepository = settlementRepository;
        }

        public async Task<GetSettlementModel?> Execute(long settlementId, long withholdingId, EditWithholdingModel model)
        {
            Settlement? settlement = await _settlementRepository.Get(settlementId) ?? throw new InvalidOperationException();
            SettlementWithholding withholding = new SettlementWithholding(model.Name, model.Value, model.Type, false);
            settlement.UpdateWithholding(withholdingId, withholding);
            await _settlementRepository.Update(settlement);
            GetSettlementModel? settlementModel = await _settlementRepository.GetSettlementModel(settlementId);
            return settlementModel;
        }
    }
}
