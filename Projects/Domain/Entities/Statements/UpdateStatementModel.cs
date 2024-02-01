namespace NUCA.Projects.Domain.Entities.Statements
{
    public class UpdateStatementModel
    {
        public List<UpdateStatementItemModel> Items { get; init; }
        public List<ExternalItemModel> ExternalSuppliesItems { get; init; }
        public List<WithholdingModel> Withholdings { get; init; }
        public bool Submit { get; init; }
    }

    public class UpdateStatementItemModel
    {
        public long TableId { get; init; }
        public long SectionId { get; init; }
        public long ItemId { get; init; }
        public double? PreviousQuantity { get; init; }
        public double TotalQuantity { get; init; }
        public double Percentage { get; init; }
        public List<PercentageDetailModel> PercentageDetails { get; init; }
        public double? PreviousNetPrice { get; init; }

    }
    public class ExternalItemModel
    {
        public long Id { get; init; }
        public string DepartmentId { get; init; }
        public long SuppliesTableId { get; init; }
        public string Index { get; init; }
        public string Content { get; init; }
        public string Unit { get; init; }
        public double UnitPrice { get; init; }
        public double PreviousQuantity { get; init; }
        public double TotalQuantity { get; init; }
        public double Percentage { get; init; }
    }
    public class PercentageDetailModel
    {
        public double Quantity { get; init; }
        public double Percentage { get; init; }
        public string? Notes { get; init; }
    }
}
