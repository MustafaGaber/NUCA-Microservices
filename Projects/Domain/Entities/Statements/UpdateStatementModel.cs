namespace NUCA.Projects.Domain.Entities.Statements
{
    public class UpdateStatementModel
    {
        public required List<UpdateStatementItemModel> Items { get; init; }
        public required List<ExternalItemModel> ExternalSuppliesItems { get; init; }
        public required List<WithholdingModel> Withholdings { get; init; }
        public required bool Submit { get; init; }
    }

    public class UpdateStatementItemModel
    {
        public required long TableId { get; init; }
        public required long SectionId { get; init; }
        public required long ItemId { get; init; }
        public required double TotalQuantity { get; init; }
        public required double Percentage { get; init; }
        public List<PercentageDetailModel>? PercentageDetails { get; init; }
        public string? Notes { get; init; }
    }
    public class ExternalItemModel
    {
        public required long Id { get; init; }
        public required int DepartmentId { get; init; }
        public required long SuppliesTableId { get; init; }
        public required string Index { get; init; }
        public required string Content { get; init; }
        public required string Unit { get; init; }
        public required double UnitPrice { get; init; }
        public required double PreviousQuantity { get; init; }
        public required double TotalQuantity { get; init; }
        public required double Percentage { get; init; }
    }
    public class PercentageDetailModel
    {
        public required double Quantity { get; init; }
        public required double Percentage { get; init; }
        public string? Notes { get; init; }
    }
}
