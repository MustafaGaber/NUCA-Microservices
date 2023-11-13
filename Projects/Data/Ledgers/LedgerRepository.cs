using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Data.Shared;
using NUCA.Projects.Domain.Entities.Ledgers;

namespace NUCA.Projects.Data.Ledgers
{
    public class LedgerRepository : Repository<Ledger, int>, ILedgerRepository
    {
        public LedgerRepository(ProjectsDatabaseContext database) : base(database)
        {
        }
    }
}
