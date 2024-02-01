using NUCA.Projects.Domain.Entities.Shared;

namespace NUCA.Projects.Domain.Entities.Statements
{
    public abstract class BaseTable
    {
        public required long Id { get; init; }
        public required long BoqTableId { get; init; }
        public required string Name { get; init; }
        public required double PriceChangePercent { get; init; }
        public required BoqTableType BoqTableType { get; init; }
        public required IReadOnlyList<StatementSection> Sections { get; init; }
        public required double TotalBeforePriceChange { get; init; }
        public required double Total { get; init; }
        public virtual bool HasQuantities => Sections.Any(i => i.HasQuantities);

    }
}
