using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;

namespace NUCA.Projects.Domain.Entities.FinanceAdmin
{
    public class WorkType : Entity<int>
    {
        public string Name { get; private set; }
        public double ValueAddedTaxPercent { get; private set; }

        protected WorkType() { }

        public WorkType(string name, double valueAddedTax)
        {
            Name = Guard.Against.NullOrEmpty(name, nameof(name));
            ValueAddedTaxPercent = Guard.Against.Negative(valueAddedTax);
        }

        public void Update(string name, double valueAddedTax)
        {
            Name = Guard.Against.NullOrEmpty(name, nameof(name));
            ValueAddedTaxPercent = Guard.Against.Negative(valueAddedTax);
        }
    }
}
