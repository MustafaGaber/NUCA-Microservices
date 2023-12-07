using Ardalis.GuardClauses;
using NUCA.Projects.Application.Statements.Models;
using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.Boqs;


namespace NUCA.Projects.Domain.Entities.Statements
{
    public class StatementSection : Entity<long>
    {
        private readonly List<StatementItem> _items = new List<StatementItem>();
        public long BoqSectionId { get; private set; }
        public long DepartmentId { get; private set; }
        public string Name { get; private set; }
        public virtual IReadOnlyList<StatementItem> Items => _items.ToList();
        public bool HasQuantities => _items.Any(i => i.HasQuantities);

        protected StatementSection() { }
        public StatementSection(BoqSection boqSection, int count)
        {
            BoqSectionId = Guard.Against.NegativeOrZero(boqSection.Id);
            DepartmentId = Guard.Against.NegativeOrZero(boqSection.Department.Id);
            Name = boqSection.Name;
            _items = boqSection.Items.Select(boqItem => new StatementItem(
                boqItem.Id,
                boqItem.Index,
                boqItem.Content,
                boqItem.Unit,
                boqItem.Quantity * count,
                boqItem.UnitPrice,
                0,
                0,
                0,
                new List<PercentageDetail>() { }
                )
            ).ToList();
        }
        public StatementSection(BoqSection boqSection, StatementSection previousStatementSection, int count)
        {
            BoqSectionId = Guard.Against.NegativeOrZero(boqSection.Id);
            Name = boqSection.Name;
            _items = boqSection.Items.Select(boqItem =>
            {
                StatementItem? previousItem = previousStatementSection._items.FirstOrDefault(i => i.BoqItemId == boqItem.Id);
                return new StatementItem(
                    boqItem.Id,
                    boqItem.Index,
                    boqItem.Content,
                    boqItem.Unit,
                    boqItem.Quantity * count,
                    boqItem.UnitPrice,
                    previousItem?.TotalQuantity ?? 0,
                    previousItem?.TotalQuantity ?? 0,
                    previousItem?.Percentage ?? 0,
                    previousItem?.PercentageDetails.Select(i =>
                       new PercentageDetail(i.Quantity, i.Percentage, i.Notes))
                       .ToList() ?? new List<PercentageDetail>() { }
                    );
            }).ToList();
        }
        public void UpdateItem(UpdateStatementItemModel model)
        {
            StatementItem item = _items.First(i => i.Id == model.ItemId);
            item.Update(model);
        }

        public double Total => _items.Sum(i => i.TotalQuantity * i.UnitPrice * i.Percentage / 100.0);
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
