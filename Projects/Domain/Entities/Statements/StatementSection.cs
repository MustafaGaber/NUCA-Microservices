using Ardalis.GuardClauses;
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
                0,//new List<StatementItemPercentage>(),
                null)
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
                    // previousItem.Percentages.ToList(),
                    previousItem?.UserId);
            }).ToList();
            /* foreach (var item in previousStatementSection.ExternalItems)
             {
                 if (!_externalItems.Any(i => i.BoqItemId == item.BoqItemId))
                 {
                     _externalItems.Add(new StatementItem(
                          item.BoqItemId,
                     item.Index,
                     item.Content,
                     item.Unit,
                     item.BoqQuantity,
                     item.UnitPrice,
                     item.TotalQuantity,
                     0,
                     item.Percentage,
                     // previousItem.Percentages.ToList(),
                     item.Notes,
                     item.UserId));
                 }
             }*/
        }
        public void UpdateItem(UpdateStatementItemModel model, long userId)
        {
            StatementItem item = _items.First(i => i.Id == model.ItemId);
            item.Update(model, userId);
        }

        public double Total => _items.Sum(i => i.TotalQuantity * i.UnitPrice * i.Percentage / 100.0);
        /*public void UpdateCurrentQuantity(long itemId, double quantity, string userId)
        {
            StatementItem boqItem = _externalItems.First(i => i.Id == itemId);
            boqItem.UpdateCurrentQuantity(quantity, userId);
        }
        public void UpdatePercentages(long itemId, List<StatementItemPercentage> percentages, string userId)
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
}
