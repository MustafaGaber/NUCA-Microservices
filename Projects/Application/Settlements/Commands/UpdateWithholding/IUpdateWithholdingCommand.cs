using NUCA.Projects.Application.Settlements.Models;

namespace NUCA.Projects.Application.Settlements.Commands.UpdateWithholding
{
    public interface IUpdateWithholdingCommand
    {
        public Task<GetSettlementModel?> Execute(long settlementId, long withholdingId, EditWithholdingModel model);
    }
}
