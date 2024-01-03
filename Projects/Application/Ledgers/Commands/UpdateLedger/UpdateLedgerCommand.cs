using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Ledgers;

namespace NUCA.Projects.Application.Ledgers.Commands.UpdateLedger
{
    public class UpdateLedgerCommand : IUpdateLedgerCommand
    {
        private readonly ILedgerRepository _ledgerRepository;
        public UpdateLedgerCommand(ILedgerRepository ledgerRepository)
        {
            _ledgerRepository = ledgerRepository;
        }
        public async Task<Ledger> Execute(int id, LedgerModel model)
        {
            Ledger? ledger = await _ledgerRepository.Get(id) ?? throw new InvalidOperationException();
            ledger.Update(model.Name, model.Index);
            await _ledgerRepository.Update(ledger);
            return ledger;
        }
    }
}
