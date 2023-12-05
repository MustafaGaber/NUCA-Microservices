using NUCA.Projects.Domain.Entities.Shared;
using NUCA.Projects.Domain.Entities.Statements;


namespace NUCA.Projects.Application.Statements.Models
{
   /* public class StatementModel
    {
        public int Index { get; init; }
        public List<Table> Tables { get; init; }
        public double PriceChangePercent { get; init; }
        public DateOnly WorksDate { get; init; }
        public DateOnly SubmissionDate { get; init; }
        public bool Final { get; init; }
        public StatementState State { get; init; }
        public double TotalWorks { get; init; }
        public double TotalSupplies { get; init; }
        public List<WithholdingModel> Withholdings { get; init; }

        public StatementModel(Statement statement)
        {
            Index = statement.Index;
            PriceChangePercent = statement.PriceChangePercent;
            WorksDate = statement.WorksDate;
            SubmissionDate = statement.SubmissionDate;
            Final = statement.Final;
            State = statement.State;
            TotalWorks = statement.TotalWorks;
            TotalSupplies = statement.TotalSupplies;
            Withholdings = statement.Withholdings.Select(w => new WithholdingModel()
            {
                Id = w.Id,
                Name = w.Name,
                Value = w.Value,
                Type = w.Type,
            }).ToList();
            Tables = statement.Tables.Select(t => new Table()
            {
                Id = t.Id,
                Name = t.Name,
                BoqTableId = t.BoqTableId,
                PriceChangePercent = t.PriceChangePercent,
                Type = t.Type,
                BoqTableType = t.BoqTableType,
                Sections = t.Sections.Select(s => new Section()
                {
                    BoqSectionId = s.Id,
                    Id = s.Id,
                    Name = s.Name,
                    Items = s.Items.Select(i => new Item()
                    {
                        Id = i.Id,
                        Index = i.Index,
                        BoqItemId = i.BoqItemId,
                        Content = i.Content,
                        Unit = i.Unit,
                        UnitPrice = i.UnitPrice,
                        BoqQuantity = i.BoqQuantity,
                        PreviousQuantity = i.PreviousQuantity,
                        TotalQuantity = i.TotalQuantity,
                        Percentage = i.Percentage,
                        UserId = i.UserId,
                    }).ToList(),
                }).ToList(),
            }).ToList();
        }

    }*/

    public class Table
    {
        public long Id { get; init; }
        public required List<Section> Sections { get; init; }
       // public required List<ExternalSuppliesItem> ExternalSuppliesItems { get; init; }
        public required long BoqTableId { get; init; }
        public required string Name { get; init; }
        public required double PriceChangePercent { get; init; }
        public required StatementTableType Type { get; init; }
        public required BoqTableType BoqTableType { get; init; }
    }

   /* public class WroksTable : Table { }
    public class SuppliesTable : Table {
        public required List<ExternalSuppliesItem> ExternalSuppliesItems { get; init; }
    }*/

    public class Section
    {
        public required long Id { get; init; }
        public required List<Item> Items { get; init; }
        public required long BoqSectionId { get; init; }
        public required string Name { get; init; }

    }

    public class Item
    {
        public required long Id { get; init; }
        public required long BoqItemId { get; init; }
        public required string Index { get; init; }
        public required string Content { get; init; }
        public required string Unit { get; init; }
        public required double BoqQuantity { get; init; }
        public required double UnitPrice { get; init; }
        public required double PreviousQuantity { get; init; }
        public required double TotalQuantity { get; init; }
        public required double Percentage { get; init; }
        //public required virtual IReadOnlyList<PercentageDetail> PercentageDetails => _percentageDetails.ToList();
        public required long? UserId { get; init; }
    }

    public class ExternalSuppliesItemModel
    {
        public required int DepartmentId { get; init; }
        public required long StatementTableId { get; init; }
        public required string Index { get; init; }
        public required string Content { get; init; }
        public required string Unit { get; init; }
        public required double UnitPrice { get; init; }
        public required double PreviousQuantity { get; init; }
        public double CurrentQuantity => TotalQuantity - PreviousQuantity;
        public required double TotalQuantity { get; init; }
        public double GrossPrice => TotalQuantity * UnitPrice;
        public required double Percentage { get; init; }
        public double NetPrice => GrossPrice * Percentage / 100.0;
        public required long? UserId { get; init; }
    }
}
