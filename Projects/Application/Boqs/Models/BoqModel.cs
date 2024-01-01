using NUCA.Projects.Domain.Entities.Boqs;
using NUCA.Projects.Domain.Entities.Shared;

namespace NUCA.Projects.Application.Boqs.Models
{
    public class BoqModel
    {
        public long Id { get; init; }
        public long ProjectId { get; init; }
        public double PriceChangePercent { get; init; }
        public List<TableModel> Tables { get; init; } = new List<TableModel>();
        public bool Approved { get; init; }
        public BoqModel(Boq boq)
        {
            Id = boq.Id;
            ProjectId = boq.ProjectId;
            PriceChangePercent = boq.PriceChangePercent;
            Tables = boq.Tables.Select(t =>
            new TableModel
            {
                Id = t.Id,
                Name = t.Name,
                Count = t.Count,
                PriceChangePercent = t.PriceChangePercent,
                Type = t.Type,
                Sections = t.Sections.Select(s =>
                new SectionModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    DepartmentId = s.DepartmentId,
                    Items = s.Items.Select(i =>
                    new ItemModel
                    {
                        Id = i.Id,
                        Index = i.Index,
                        Content = i.Content,
                        Unit = i.Unit,
                        Quantity = i.Quantity,
                        UnitPrice = i.UnitPrice
                    }).ToList()
                }).ToList()
            }).ToList();
            Approved = boq.Approved;
        }
    }

    public class TableModel
    {
        public List<SectionModel> Sections { get; init; } = new List<SectionModel>();
        public long Id { get; init; }
        public string Name { get; init; }
        public int Count { get; init; }
        public BoqTableType Type { get; init; }
        public double PriceChangePercent { get; init; }
    }

    public class SectionModel
    {
        public long Id { get; init; }
        public List<ItemModel> Items { get; init; } = new List<ItemModel>();
        public required string Name { get; init; }
        public string DepartmentId { get; init; }

    }

    public class ItemModel
    {
        public long Id { get; init; }
        public string Index { get; init; }
        public string Content { get; init; }
        public string Unit { get; init; }
        public double Quantity { get; init; }
        public double UnitPrice { get; init; }
    }

}
