using NUCA.Projects.Domain.Entities.Shared;
using NUCA.Projects.Domain.Entities.Statements;

namespace NUCA.Projects.Application.Statements.Models
{
    public class StatementModel
    {
        public int Index { get; set; }
        public List<Table> Tables { get; set; }
        public double PriceChangePercent { get; set; }
        public DateOnly WorksDate { get; set; }
        public DateOnly SubmissionDate { get; set; }
        public bool Final { get; set; }
        public StatementState State { get; set; }
        public double TotalWorks { get; set; }
        public double TotalSupplies { get; set; }
        public List<WithholdingModel> Withholdings { get; set; }

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
                Sections = t.Sections.Select(s => new Section() { 
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
                        Notes = i.Notes,
                        UserId = i.UserId,
                    }).ToList(),
                }).ToList(),
            }).ToList();
        }

    }

    public class Table
    {
        public long Id { get; set; }
        public List<Section> Sections { get; set; }
        public long BoqTableId { get; set; }
        public string Name { get; set; }
        public double PriceChangePercent { get; set; }
        public StatementTableType Type { get; set; }
        public BoqTableType BoqTableType { get; set; }
    }

    public class Section
    {
        public long Id { get; set; }
        public List<Item> Items { get; set; }
        public long BoqSectionId { get; set; }
        public string Name { get; set; }

    }

    public class Item
    {
        public long Id { get; set; }
        public long BoqItemId { get; set; }
        public string Index { get; set; }
        public string Content { get; set; }
        public string Unit { get; set; }
        public double BoqQuantity { get; set; }
        public double UnitPrice { get; set; }
        public double PreviousQuantity { get; set; }
        public double TotalQuantity { get; set; }
        public double Percentage { get; set; }
        //public virtual IReadOnlyList<StatementItemPercentage> Percentages => _percentages.ToList();
        public string? Notes { get; set; }
        public long? UserId { get; set; }
    }
}
