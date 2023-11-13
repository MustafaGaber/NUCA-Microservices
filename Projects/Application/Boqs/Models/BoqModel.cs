using NUCA.Projects.Domain.Entities.Boqs;
using NUCA.Projects.Domain.Entities.Shared;

namespace NUCA.Projects.Application.Boqs.Models
{
    public class BoqModel
    {
        public double PriceChangePercent { get; set; }
        public List<TableModel> Tables { get; set; } = new List<TableModel>();
        public BoqModel(Boq boq)
        {
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
                    DepartmentId = s.Department.Id,
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
        }
    }

    public class TableModel
    {
        public List<SectionModel> Sections { get; set; } = new List<SectionModel>();
        public long Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public BoqTableType Type { get; set; }
        public double PriceChangePercent { get; set; }
    }

    public class SectionModel
    {
        public long Id { get; set; }
        public List<ItemModel> Items { get; set; } = new List<ItemModel>();
        public string Name { get; set; }
        public int DepartmentId { get; set; }

    }

    public class ItemModel
    {
        public long Id { get; set; }
        public string Index { get; set; }
        public string Content { get; set; }
        public string Unit { get; set; }
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
    }

}
