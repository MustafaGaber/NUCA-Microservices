using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;

namespace NUCA.Projects.Domain.Entities.Settings
{
    public class WorkType : Entity
    {
        public string Name { get; private set; }
        public double ValueAddedTaxPercent { get; private set; }
        public double CommercialIndustrialTaxPercent { get; private set; }
        public double SelfEmploymentTaxPercent { get; private set; }
        protected WorkType() { }

        public WorkType(string name, double valueAddedTaxPercent, double commercialIndustrialTaxPercent, double selfEmploymentTaxPercent)
        {
            Update(
                name: name,
                valueAddedTaxPercent: valueAddedTaxPercent,
                commercialIndustrialTaxPercent: commercialIndustrialTaxPercent,
                selfEmploymentTaxPercent: selfEmploymentTaxPercent
            );
        }

        public void Update(string name, double valueAddedTaxPercent, double commercialIndustrialTaxPercent, double selfEmploymentTaxPercent)
        {
            Name = Guard.Against.NullOrEmpty(name, nameof(name));
            ValueAddedTaxPercent = Guard.Against.Negative(valueAddedTaxPercent);
            CommercialIndustrialTaxPercent = Guard.Against.Negative(commercialIndustrialTaxPercent);
            SelfEmploymentTaxPercent = Guard.Against.Negative(selfEmploymentTaxPercent);
        }
    }
}
