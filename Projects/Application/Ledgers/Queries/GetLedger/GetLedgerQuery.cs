using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Application.Ledgers.Queries.GetLedger;

namespace NUCA.Projects.Application.Ledgers.Queries.GetLedger
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
                Name = ledger.Name,
                Index = ledger.Index,
            } : null;
        }

    }
}
