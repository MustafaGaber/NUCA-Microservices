using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Application.Settings.Ledgers.Models;

namespace NUCA.Projects.Application.Settings.Ledgers.Queries.GetLedger
{
    public class GetLedgerQuery : IGetLedgerQuery
    {
        private readonly ILedgerRepository _repository;

        public GetLedgerQuery(ILedgerRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetLedgerModel?> Execute(int id)
        {
            var ledger = await _repository.Get(id);
            return ledger != null ? new GetLedgerModel
            {
                Id = ledger.Id,
                ParentId = ledger.ParentId,
                Name = ledger.Name,
                Code = ledger.Code,
                ParentFullPath = ledger.ParentFullPath
            } : null;
        }

    }
}
