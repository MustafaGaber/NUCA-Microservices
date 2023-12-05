using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;

namespace NUCA.Projects.Domain.Entities.Statements
{
    public class PercentageDetail : Entity<long>
    {
        public double Quantity { get; private set; }
        public double Percentage { get; private set; }
        public string? Notes { get; private set; }

        public PercentageDetail(double quantity, double percentage, string? notes)
        {
            Quantity = quantity;
            Percentage = Guard.Against.OutOfRange(percentage, nameof(percentage), 0 , 100);
            Notes = notes;
        }
    }
}
