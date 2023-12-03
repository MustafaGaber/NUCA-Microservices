/*using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;

namespace NUCA.Projects.Domain.Entities.Statements
{
    public class ExternalSuppliesTable : Entity<long>
    {
        public long StatementId { get; private set; }
        public int DepartmentId { get; private set; }
        
        private readonly List<ExternalSuppliesItem> _items = new List<ExternalSuppliesItem>();
        public virtual IReadOnlyList<ExternalSuppliesItem> Items => _items.ToList();
        public double Total => Items.Sum(i => i.NetPrice);
        public ExternalSuppliesTable(int departmentId)
        {
            DepartmentId = Guard.Against.NegativeOrZero(departmentId);
        }
        public ExternalSuppliesTable(ExternalSuppliesTable previousTable)
        {
            DepartmentId = Guard.Against.NegativeOrZero(previousTable.DepartmentId);
            _items = previousTable._items.Select(i => new ExternalSuppliesItem());
        }
        public void UpdateItems(List<ExternalSuppliesItem> items, long userId)
        {
            _items.RemoveAll(item => item.PreviousQuantity == 0 && !items.Any(i => i.Id == item.Id));
            items.ForEach(i =>
            {
                ExternalSuppliesItem? item = _items.Find(_w => _w.Id == i.Id);
                if (item != null)
                {
                    item.Update(i.TotalQuantity, i.Percentage, userId);
                }
            });
            _items.AddRange(items.Where(i => i.Id == 0));
        }
        public void UpdateItem(UpdateStatementItemModel model, long userId)
        {
            ExternalSuppliesItem item = _externalItems.First(i => i.Id == model.ItemId);
            item.Update(model, userId);
        }


    }
}
*/