using NUCA.Projects.Domain.Entities.Boqs;
using NUCA.Projects.Domain.Entities.Shared;

namespace NUCA.Projects.Domain.Entities.Statements
{
    public class SuppliesTable : BaseTable
    {
        public required IReadOnlyList<ExternalSuppliesItem> ExternalSuppliesItems { get; init; }
        public override bool HasQuantities => base.HasQuantities || ExternalSuppliesItems.Any(i => i.HasQuantities);
        /*public override double TotalBeforePriceChange => Sections.Sum(s => s.Total) + ExternalSuppliesItems.Sum(t => t.NetPrice);
        public override double Total => TotalBeforePriceChange;*/
    }
}
