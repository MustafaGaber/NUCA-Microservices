using NUCA.Projects.Application.Interfaces.Persistence;

namespace NUCA.Projects.Application.Settings.Ledgers.Queries.CanDeleteLedger
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
            var hasProjects = false; // await _database.LedgerHasSettlements(id);
            return !hasProjects;
        }
    }
}
