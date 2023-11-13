using NUCA.Projects.Domain.Entities.Ledgers;

namespace NUCA.Projects.Application.Ledgers.Commands.UpdateLedger
{
    public interface IUpdateLedgerCommand
    {
        Task<Ledger> Execute(int id, LedgerModel model);
    }
}
