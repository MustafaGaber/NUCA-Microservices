using NUCA.Projects.Domain.Common;

namespace NUCA.Projects.Domain.Entities.Adjustments
{
    public class DeductedAdvancedPayments: Entity
    {
        public long ProjectId { get; private set; }
        public long AdjustmentId { get; private set; }
        public int StatementIndex { get; private set; }
        public double Amount {  get; private set; }
    }
}
