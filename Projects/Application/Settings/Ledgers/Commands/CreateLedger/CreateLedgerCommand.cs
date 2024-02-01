using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Application.Settings.Ledgers.Models;
using NUCA.Projects.Domain.Entities.Settings;

namespace NUCA.Projects.Application.Settings.Ledgers.Commands.CreateLedger
{
    public class CreateLedgerCommand : ICreateLedgerCommand
    {
        private readonly ILedgerRepository _ledgerRepository;
        public CreateLedgerCommand(ILedgerRepository ledgerRepository)
        {
            _ledgerRepository = ledgerRepository;
        }
        public async Task<GetLedgerModel> Execute(LedgerModel model)
        {
            var parent = model.ParentId == null ? null : await _ledgerRepository.Get((long)model.ParentId!);
            var ledger = await _ledgerRepository.Add(new Ledger(model.Name, model.Code, parent));
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
