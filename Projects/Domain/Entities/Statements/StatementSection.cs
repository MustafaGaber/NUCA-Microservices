using Ardalis.GuardClauses;
using NUCA.Projects.Application.Statements.Models;
using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.Boqs;


namespace NUCA.Projects.Domain.Entities.Statements
{
    public class StatementSection : Entity
    {
        private readonly List<StatementItem> _items = new List<StatementItem>();
        public long BoqSectionId { get; private set; }
        public string DepartmentId { get; private set; }
        public string Name { get; private set; }
        public virtual IReadOnlyList<StatementItem> Items => _items.ToList();
        public bool HasQuantities => _items.Any(i => i.HasQuantities);
        protected StatementSection() { }
        public StatementSection(BoqSection boqSection, int count, bool supplies)
        {
            BoqSectionId = Guard.Against.NegativeOrZero(boqSection.Id);
            DepartmentId = Guard.Against.NullOrEmpty(boqSection.DepartmentId);
            Name = boqSection.Name;
            _items = boqSection.Items.Where(i => !i.IsPerformanceRate || !supplies).Select(boqItem => new StatementItem(
                boqItemId: boqItem.Id,
                index: boqItem.Index,
                content: boqItem.Content,
                unit: boqItem.Unit,
                quantity: boqItem.Quantity * count,
                unitPrice: boqItem.UnitPrice,
                workTypeId: boqItem.WorkTypeId,
                isPerformanceRate: boqItem.IsPerformanceRate,
                costCenterId: boqItem.CostCenterId,
                sovereign: boqItem.Sovereign,
                previousQuantity: 0,
                totalQuantity: 0,
                percentage: 0,
                percentageDetails: new List<PercentageDetail>() { },
                previousNetPrice: 0
                )
            ).ToList();
        }
        public StatementSection(BoqSection boqSection, StatementSection previousStatementSection, int count, bool supplies)
        {
            BoqSectionId = Guard.Against.NegativeOrZero(boqSection.Id);
            DepartmentId = Guard.Against.NullOrEmpty(boqSection.DepartmentId);
            Name = boqSection.Name;
            _items = boqSection.Items.Where(i => !i.IsPerformanceRate || !supplies).Select(boqItem =>
            {
                StatementItem? previousItem = previousStatementSection._items.FirstOrDefault(i => i.BoqItemId == boqItem.Id);
                return new StatementItem(
                      boqItemId: boqItem.Id,
                      index: boqItem.Index,
                      content: boqItem.Content,
                      unit: boqItem.Unit,
                      quantity: boqItem.Quantity * count,
                      unitPrice: boqItem.UnitPrice,
                      workTypeId: boqItem.WorkTypeId,
                      isPerformanceRate: boqItem.IsPerformanceRate,
                      costCenterId: boqItem.CostCenterId,
                      sovereign: boqItem.Sovereign,
                      previousQuantity: previousItem?.TotalQuantity ?? 0,
                      totalQuantity: previousItem?.TotalQuantity ?? 0,
                      percentage: previousItem?.Percentage ?? 0,
                      percentageDetails: previousItem?.PercentageDetails.Select(i =>
                       new PercentageDetail(i.Quantity, i.Percentage, i.Notes))
                       .ToList() ?? new List<PercentageDetail>() { },
                      previousNetPrice: previousItem?.NetPrice ?? 0
                    );
            }).ToList();
        }
        public void UpdateItem(long itemId, double? previousQuantity, double totalQuantity, double percentage, List<PercentageDetail> percentageDetails, double? previousNetPrice)
        {
            StatementItem item = _items.First(i => i.Id == itemId);
            item.Update(
                previousQuantity: previousQuantity,
                totalQuantity: totalQuantity,
                percentage: percentage,
                percentageDetails: percentageDetails,
                previousNetPrice: previousNetPrice
            );
        }

        public double Total => _items.Sum(i => i.NetPrice);
        /*public void UpdateCurrentQuantity(long itemId, double quantity, string userId)
        {
            StatementItem boqItem = _externalItems.First(i => i.Id == itemId);
            boqItem.UpdateCurrentQuantity(quantity, userId);
        }
        public void UpdatePercentages(long itemId, List<PercentageDetail> percentages, string userId)
        {
            StatementItem boqItem = _externalItems.First(i => i.Id == itemId);
            boqItem.UpdatePercentages(percentages, userId);
        }
        public void UpdateNotes(long itemId, string notes, string userId)
        {
            StatementItem boqItem = _externalItems.First(i => i.Id == itemId);
            boqItem.UpdateNotes(notes, userId);
        }*/
    }

    /* public class WroksSection : StatementSection
     {
         protected WroksSection()
         {
         }

         public WroksSection(BoqSection boqSection, int count) : base(boqSection, count)
         {
         }

         public WroksSection(BoqSection boqSection, StatementSection previousStatementSection, int count) : base(boqSection, previousStatementSection, count)
         {
         }
     }

     public class SuppliesSection : StatementSection
     {
         protected SuppliesSection()
         {
         }

         public SuppliesSection(BoqSection boqSection, int count) : base(boqSection, count)
         {
         }

         public SuppliesSection(BoqSection boqSection, StatementSection previousStatementSection, int count) : base(boqSection, previousStatementSection, count)
         {
         }
     }*/
}
