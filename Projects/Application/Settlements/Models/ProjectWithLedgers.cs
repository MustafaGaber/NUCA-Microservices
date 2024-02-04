using NUCA.Projects.Domain.Entities.Settings;

namespace NUCA.Projects.Application.Settlements.Models
{
    public class ProjectWithLedgers
    {
        public required long Id { get; init; }
        public required Ledger? FromLedger { get; init; }
        public required Ledger? ToLedger { get; init; }
        public required Ledger? AdvancePaymentLedger { get; init; }

    }
}
