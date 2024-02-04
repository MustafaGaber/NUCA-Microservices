using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Data;
using NUCA.Projects.Domain.Entities.Settlements;

namespace NUCA.Projects.Application.Settlements.Queries.GetJournalVoucherModel
{
    public class GetJournalVoucherSettlementQuery : IGetJournalVoucherSettlementQuery
    {
        private readonly ProjectsDatabaseContext _database;

        public GetJournalVoucherSettlementQuery(ProjectsDatabaseContext database)
        {
            _database = database;
        }

        public async Task<Settlement?> Execute(long id)
        {
            var settlement = await _database.Settlements
                 .Include(a => a.Withholdings)
                 .Include(a => a.Statement)
                 .Include(a => a.Project).ThenInclude(p => p.Company)
                 .Include(a => a.Project).ThenInclude(p => p.FromLedger).ThenInclude(l => l.Parent)
                 .Include(a => a.Project).ThenInclude(p => p.ToLedger).ThenInclude(l => l.Parent)
                 .Include(a => a.Project).ThenInclude(p => p.AdvancePaymentLedger).ThenInclude(l => l.Parent)
                 .FirstOrDefaultAsync(a => a.Id == id) ?? throw new ArgumentNullException("Settlement not found");

            return settlement;
        }
    }
}
