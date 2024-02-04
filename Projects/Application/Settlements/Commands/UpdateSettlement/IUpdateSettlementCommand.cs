using NUCA.Projects.Application.Settlements.Models;

namespace NUCA.Projects.Application.Settlements.Commands.UpdateSettlement
{
    public interface IUpdateSettlementCommand
    {
        Task<GetSettlementModel> Execute(long settlementId, UpdateSettlementModel model);

    }
}
