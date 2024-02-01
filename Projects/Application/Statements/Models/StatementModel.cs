using NUCA.Projects.Domain.Entities.Projects;
using NUCA.Projects.Domain.Entities.Shared;
using NUCA.Projects.Domain.Entities.Statements;


namespace NUCA.Projects.Application.Statements.Models
{
    public class StatementModel
    {
        public long Id { get; private set; }
        public int Index { get; private set; }
        public List<Table> Tables { get; private set; }
        public double PriceChangePercent { get; private set; }
        public DateOnly WorksDate { get; private set; }
        public DateOnly SubmissionDate { get; private set; }
        public bool Final { get; private set; }
        public StatementState State { get; private set; }
        public double TotalWorks { get; private set; }
        public double TotalSupplies { get; private set; }
        public List<WithholdingModel> Withholdings { get; private set; }
        public List<ExternalSuppliesItemModel> ExternalSuppliesItems { get; private set; }
        public List<PrivilegeModel> Privileges { get; private set; }
        public bool IsFirst { get; private set; }
        public StatementModel(Statement statement, List<Privilege> privileges, bool isFirst)
        {
            Id = statement.Id;
            Index = statement.Index;
            IsFirst = isFirst;
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
                        PercentageDetails = i.PercentageDetails.Select(d => new PercentageDetailModel()
                        {
                            Notes = d.Notes,
                            Quantity = d.Quantity,
                            Percentage = d.Percentage
                        }).ToList(),
                        IsPerformanceRate = i.IsPerformanceRate,
                        PreviousNetPrice = i.PreviousNetPrice,
                    }).ToList(),
                }).ToList(),
            }).ToList();
            ExternalSuppliesItems = statement.ExternalSuppliesItems.Select(item => new ExternalSuppliesItemModel()
            {
                Id = item.Id,
                DepartmentId = item.DepartmentId,
                SuppliesTableId = item.SuppliesTableId,
                Index = item.Index,
                Content = item.Content,
                Unit = item.Unit,
                UnitPrice = item.UnitPrice,
                TotalQuantity = item.TotalQuantity,
                Percentage = item.Percentage,
                PreviousQuantity = item.PreviousQuantity,
            }).ToList();
            Privileges = privileges.Select( p=> new PrivilegeModel()
            {
                DepartmentId= p.DepartmentId,
                Type = p.Type,
            }).ToList();
        }

    }

    public class Table
    {
        public required long Id { get; init; }
        public required List<Section> Sections { get; init; }
        public required long BoqTableId { get; init; }
        public required string Name { get; init; }
        public required double PriceChangePercent { get; init; }
        public required StatementTableType Type { get; init; }
        public required BoqTableType BoqTableType { get; init; }
    }


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
        public required IReadOnlyList<PercentageDetailModel> PercentageDetails { get; init; }
        public required bool IsPerformanceRate { get; init; }
        public required double PreviousNetPrice { get; init; }
    }

    public class ExternalSuppliesItemModel
    {
        public required long Id { get; init; }
        public required string DepartmentId { get; init; }
        public required long SuppliesTableId { get; init; }
        public required string Index { get; init; }
        public required string Content { get; init; }
        public required string Unit { get; init; }
        public required double UnitPrice { get; init; }
        public required double PreviousQuantity { get; init; }
        public  double CurrentQuantity => TotalQuantity - PreviousQuantity;
        public required double TotalQuantity { get; init; }
        public  double GrossPrice => TotalQuantity * UnitPrice;
        public required double Percentage { get; init; }
        public  double NetPrice => GrossPrice * Percentage / 100.0;
    }

    public class PercentageDetailModel
    {
        public required double Quantity { get; init; }
        public required double Percentage { get; init; }
        public required string? Notes { get; init; }
    }

    public class PrivilegeModel
    {
        public required PrivilegeType Type { get; init; }
        public required string? DepartmentId { get; init; }
    }
}
