using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.Settings;

namespace NUCA.Projects.Domain.Entities.Boqs
{
    public class BoqItem : Entity
    {
        public string Index { get; private set; }
        public string Content { get; private set; }
        public string Unit { get; private set; }
        public double Quantity { get; private set; }
        public double UnitPrice { get; private set; }
        public WorkType WorkType { get; private set; }
        public long WorkTypeId { get; private set; }
        public bool IsPerformanceRate { get; private set; }
        public CostCenter CostCenter { get; private set; }
        public long CostCenterId { get; private set; }
        public bool Sovereign { get; private set; }

        protected BoqItem() { }
        public BoqItem(string index, string content, string unit, double quantity,
            double unitPrice, WorkType workType, bool isPerformanceRate, bool sovereign,
            CostCenter costCenter)
        {
            Update(
                index: index,
                content: content,
                unit: unit,
                quantity: quantity,
                unitPrice: unitPrice,
                workType: workType,
                isPerformanceRate: isPerformanceRate,
                sovereign: sovereign,
                costCenter: costCenter
           );
        }

        internal void Update(string index, string content, string unit, double quantity, double unitPrice, WorkType workType, bool isPerformanceRate, bool sovereign, CostCenter costCenter)
        {
            Index = Guard.Against.NullOrEmpty(index, nameof(index));
            Content = Guard.Against.NullOrEmpty(content, nameof(content));
            Unit = Guard.Against.NullOrEmpty(unit, nameof(unit));
            Quantity = Guard.Against.NegativeOrZero(quantity, nameof(quantity));
            UnitPrice = Guard.Against.NegativeOrZero(unitPrice, nameof(unitPrice));
            IsPerformanceRate = isPerformanceRate;
            WorkType = Guard.Against.Null(workType);
            WorkTypeId = Guard.Against.NegativeOrZero(workType.Id);
            Sovereign = sovereign;
            CostCenter = Guard.Against.Null(costCenter);
            CostCenterId = Guard.Against.NegativeOrZero(costCenter.Id);
        }
    }
}
