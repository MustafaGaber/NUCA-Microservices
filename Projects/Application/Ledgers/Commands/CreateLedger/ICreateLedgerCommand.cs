using NUCA.Projects.Domain.Entities;
using NUCA.Projects.Domain.Entities.Ledgers;

namespace NUCA.Projects.Application.Ledgers.Commands.CreateLedger
{
    public interface ICreateLedgerCommand
    {
        Task<Ledger> Execute(LedgerModel model);
    }
}
