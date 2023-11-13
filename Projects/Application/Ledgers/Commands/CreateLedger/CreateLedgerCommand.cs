using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Ledgers;

namespace NUCA.Projects.Application.Ledgers.Commands.CreateLedger
{
    public class CreateLedgerCommand : ICreateLedgerCommand
    {
        private readonly ILedgerRepository _ledgerRepository;
        public CreateLedgerCommand(ILedgerRepository ledgerRepository)
        {
            _ledgerRepository = ledgerRepository;
        }
        public Task<Ledger> Execute(LedgerModel model)
        {
            return _ledgerRepository.Add(new Ledger(model.Name, model.Index));
        }

    }
}
