using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Application.Settings.Ledgers.Models;

namespace NUCA.Projects.Application.Settings.Ledgers.Queries.GetLedgers
{
    public class GetLedgersQuery : IGetLedgersQuery
    {

        private readonly ILedgerRepository _repository;

        public GetLedgersQuery(ILedgerRepository repository)
        {
            _repository = repository;
        }

        public Task<List<GetLedgerModel>> Execute()
        {
            return _repository.Select(ledger => new GetLedgerModel
            {
                Id = ledger.Id,
                ParentId = ledger.ParentId,
                Name = ledger.Name,
                Code = ledger.Code,
                ParentFullPath = ledger.ParentFullPath
            });
        }
    }
}
