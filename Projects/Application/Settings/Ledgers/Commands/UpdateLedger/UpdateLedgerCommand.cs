using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Application.Settings.Ledgers.Models;
using NUCA.Projects.Domain.Entities.Settings;

namespace NUCA.Projects.Application.Settings.Ledgers.Commands.UpdateLedger
{
    public class UpdateLedgerCommand : IUpdateLedgerCommand
    {
        private readonly ILedgerRepository _ledgerRepository;
        public UpdateLedgerCommand(ILedgerRepository ledgerRepository)
        {
            _ledgerRepository = ledgerRepository;
        }
        public async Task<GetLedgerModel> Execute(long id, LedgerModel model)
        {
            Ledger? ledger = await _ledgerRepository.Get(id) ?? throw new InvalidOperationException();
            var parent = model.ParentId == null ? null : await _ledgerRepository.Get((long)model.ParentId!);
            ledger.Update(model.Name, model.Code, parent);
            await _ledgerRepository.Update(ledger);
            return new GetLedgerModel()
            {
                Id = ledger.Id,
                Name = ledger.Name,
                Code = ledger.Code,
                ParentId = ledger.ParentId,
                ParentFullPath = ledger.ParentFullPath
            };
        }
    }
}
