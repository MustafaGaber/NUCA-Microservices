using NUCA.Projects.Application.Settlements.Models;

namespace NUCA.Projects.Application.Settlements.Commands.Submit
{
    public interface ISubmitCommand
    {
        public Task<GetSettlementModel?> Execute(long settlementId);

    }
}
