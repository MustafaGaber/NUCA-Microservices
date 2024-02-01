using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;

namespace NUCA.Projects.Domain.Entities.Statements
{
    public class ExternalSuppliesItem : Entity
    {
        public long SuppliesTableId { get; private set; }
        public string DepartmentId { get; private set; }
        public string Index { get; private set; }
        public string Content { get; private set; }
        public string Unit { get; private set; }
        public double UnitPrice { get; private set; }
        public double PreviousQuantity { get; private set; }
        public double CurrentQuantity => TotalQuantity - PreviousQuantity;
        public double TotalQuantity { get; private set; }
        public double GrossPrice => TotalQuantity * UnitPrice;
        public double Percentage { get; private set; }
        public double NetPrice => GrossPrice * Percentage / 100.0;
        public long CostCenterId { get; private set; }
        public bool HasQuantities => !(PreviousQuantity == 0 && TotalQuantity == 0);
        protected ExternalSuppliesItem() { }
        public ExternalSuppliesItem(long suppliesTableId, string departmentId, string index, string content, string unit, double unitPrice,
            double previousQuantity, double totalQuantity, double percentage, long costCenterId)
        {
            DepartmentId = Guard.Against.NullOrEmpty(departmentId);
            SuppliesTableId = Guard.Against.NegativeOrZero(suppliesTableId);
            Index = Guard.Against.NullOrEmpty(index, nameof(index));
            Content = Guard.Against.NullOrEmpty(content, nameof(content));
            Unit = Guard.Against.NullOrEmpty(unit, nameof(unit));
            UnitPrice = Guard.Against.NegativeOrZero(unitPrice, nameof(unitPrice));
            PreviousQuantity = Guard.Against.Negative(previousQuantity, nameof(previousQuantity));
            TotalQuantity = totalQuantity;
            Percentage = Guard.Against.OutOfRange(percentage, nameof(percentage), 0, 100);
            CostCenterId = costCenterId;
        }
        public void Update(double totalQuantity, double percentage)
        {
            TotalQuantity = Guard.Against.Negative(totalQuantity);
            Percentage = Guard.Against.OutOfRange(percentage, nameof(percentage), 0, 100);
        }

    }
}
