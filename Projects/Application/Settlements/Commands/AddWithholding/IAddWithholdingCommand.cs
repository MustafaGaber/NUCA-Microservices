using NUCA.Projects.Application.Settlements.Models;

namespace NUCA.Projects.Application.Settlements.Commands.AddWithholding
{
    public interface IAddWithholdingCommand
    {
        public Task<GetSettlementModel?> Execute(long settlementId, EditWithholdingModel model);
    }
}
