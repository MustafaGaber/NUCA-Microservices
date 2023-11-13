using NUCA.Projects.Domain.Entities.Statements;

namespace NUCA.Projects.Application.Statements.Commands.UpdateStatement
{
    public class UpdateStatementModel
    {
        public List<UpdateStatementItemModel> Items { get; set; }
        public List<WithholdingModel> Withholdings { get; set; }
    }

    public class UpdateStatementItemModel
    {
        public long TableId { get; set; }
        public long SectionId { get; set; }
        public long ItemId { get; set; }
        public bool IsSupplies { get; set; }
        public double TotalQuantity { get; set; }
        public double Percentage { get; set; }
        // public List<ItemPercentageModel> Percentages = new List<ItemPercentageModel>();
        public string? Notes { get; set; }
    }

    public class ItemPercentageModel
    {
        public double Quantity { get; set; }
        public double Percentage { get; set; }
        public string Notes { get; set; }
    }
}
