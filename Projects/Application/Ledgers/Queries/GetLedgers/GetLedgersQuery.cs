using NUCA.Projects.Application.Interfaces.Persistence;


namespace NUCA.Projects.Application.Ledgers.Queries.GetLedgers
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
                Name = ledger.Name,
                Index = ledger.Index,
            });
        }
    }
}
