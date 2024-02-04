using NUCA.Projects.Application.Settlements.Models;

namespace NUCA.Projects.Application.Settlements.Commands.DeleteWithholding
{
    public interface IDeleteWithholdingCommand
    {
        public Task<GetSettlementModel?> Execute(long settlementId, long withholdingId);

    }
}
