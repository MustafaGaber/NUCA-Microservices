using NUCA.Projects.Domain.Entities.Boqs;
using NUCA.Projects.Domain.Entities.FinanceAdmin;
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
                BoqType = t.Type,
                WorkTypeId = t.WorkTypeId,
                CostCenterId = t.CostCenterId,
                Sovereign = t.Sovereign,
                IsPerformanceRate = t.IsPerformanceRate,
                Sections = t.Sections.Select(s =>
                new SectionModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    DepartmentId = s.DepartmentId,
                    WorkTypeId = s.WorkTypeId,
                    CostCenterId = s.CostCenterId,
                    Sovereign = s.Sovereign,
                    IsPerformanceRate = s.IsPerformanceRate,
                    Items = s.Items.Select(i =>
                    new ItemModel
                    {
                        Id = i.Id,
                        Index = i.Index,
                        Content = i.Content,
                        Unit = i.Unit,
                        Quantity = i.Quantity,
                        UnitPrice = i.UnitPrice,
                        WorkTypeId = i.WorkTypeId,
                        CostCenterId = i.CostCenterId,
                        Sovereign = i.Sovereign,
                        IsPerformanceRate = i.IsPerformanceRate,
                    }).ToList()
                }).ToList()
            }).ToList();
            Approved = boq.Approved;
        }
    }

    public class TableModel
    {
        public required List<SectionModel> Sections { get; init; } = new List<SectionModel>();
        public required long Id { get; init; }
        public required string Name { get; init; }
        public required int Count { get; init; }
        public required BoqTableType BoqType { get; init; }
        public required double PriceChangePercent { get; init; }
        public required long WorkTypeId { get; init; }
        public required bool IsPerformanceRate { get; init; }
        public required long CostCenterId { get; init; }
        public required bool Sovereign { get; init; }
    }

    public class SectionModel
    {
        public required long Id { get; init; }
        public required List<ItemModel> Items { get; init; } = new List<ItemModel>();
        public required string Name { get; init; }
        public required string DepartmentId { get; init; }
        public required long WorkTypeId { get; init; }
        public required bool IsPerformanceRate { get; init; }
        public required long CostCenterId { get; init; }
        public required bool Sovereign { get; init; }
    }

    public class ItemModel
    {
        public required long Id { get; init; }
        public required string Index { get; init; }
        public required string Content { get; init; }
        public required string Unit { get; init; }
        public required double Quantity { get; init; }
        public required double UnitPrice { get; init; }
        public required long WorkTypeId { get; init; }
        public required bool IsPerformanceRate { get; init; }
        public required long CostCenterId { get; init; }
        public required bool Sovereign { get; init; }
    }

}
