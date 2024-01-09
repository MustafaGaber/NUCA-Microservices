using NUCA.Projects.Application.Interfaces.Persistence;

namespace NUCA.Projects.Application.Ledgers.Queries.CanDeleteLedger
{
    public class CanDeleteLedgerQuery : ICanDeleteLedgerQuery
    {
        private readonly ILedgerRepository _repository;
        public CanDeleteLedgerQuery(ILedgerRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Execute(long id)
        {
            var hasAdjustments = true; // await _repository.LedgerHasAdjustments(id);
            return !hasAdjustments;
        }
    }
}
