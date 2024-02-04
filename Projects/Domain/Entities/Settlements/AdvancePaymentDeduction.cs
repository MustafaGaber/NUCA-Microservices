using NUCA.Projects.Domain.Common;

namespace NUCA.Projects.Domain.Entities.Settlements
{
    public class AdvancePaymentDeduction : Entity
    {
        public required long ProjectId { get; init; }
        public long? SettlementId { get; init; }
        public required double Amount { get; init; }
    }
}
