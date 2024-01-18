using NUCA.Projects.Domain.Common;

namespace NUCA.Projects.Domain.Entities.Adjustments
{
    public class AdvancedPaymentDeduction: Entity
    {
        public required long ProjectId { get; init; }
        public long AdjustmentId { get; init; }
        public required double Amount {  get; init; }
    }
}
