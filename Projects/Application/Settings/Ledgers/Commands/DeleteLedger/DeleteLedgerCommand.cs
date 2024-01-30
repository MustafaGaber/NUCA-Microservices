using NUCA.Projects.Application.Interfaces.Persistence;

namespace NUCA.Projects.Application.Settings.Ledgers.Commands.DeleteLedger
{
    public class DeleteLedgerCommand : IDeleteLedgerCommand
    {
        private readonly ILedgerRepository _ledgerRepository;
        public DeleteLedgerCommand(ILedgerRepository ledgerRepository)
        {
            _ledgerRepository = ledgerRepository;
        }
        public async Task Execute(long id)
        {
            bool hasAdjustments = true; //await _ledgerRepository.LedgerHasAdjustments(id);
            if (!hasAdjustments)
            {
                await _ledgerRepository.Delete(id);
            }
            else
            {
                throw new InvalidOperationException("Ledger has projects");
            }
        }
    }
}
