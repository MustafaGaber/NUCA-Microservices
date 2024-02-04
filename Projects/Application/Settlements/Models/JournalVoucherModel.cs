using NUCA.Projects.Domain.Entities.Settlements;

namespace NUCA.Projects.Application.Settlements.Models
{
    public class JournalVoucherModel
    {
        public Settlement Settlement { get; init; }
        public ProjectWithLedgers Ledgers { get; init; }
    }
}
