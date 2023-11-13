using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.Departments;
using NUCA.Projects.Domain.Entities.Shared;

namespace NUCA.Projects.Domain.Entities.Boqs
{
    public class Boq : AggregateRoot<long>
    {
        private readonly List<BoqTable> _tables = new List<BoqTable>();
        public double PriceChangePercent { get; private set; }
        public virtual IReadOnlyList<BoqTable> Tables => _tables.ToList();
        protected Boq() { }
        public Boq(long id, double priceChangePercent)
        {
            Id = Guard.Against.Null(id, nameof(id));
            PriceChangePercent = Guard.Against.OutOfRange(priceChangePercent, nameof(priceChangePercent), -100, double.MaxValue);
        }
        public void UpdateBoq(double priceChangePercent)
        {
            PriceChangePercent = Guard.Against.OutOfRange(priceChangePercent, nameof(priceChangePercent), -100, double.MaxValue);
        }
        public void AddTable(string name, int count, double priceChangePercent, BoqTableType type)
        {
            Guard.Against.NegativeOrZero(count, nameof(count));
            Guard.Against.OutOfRange(priceChangePercent, nameof(priceChangePercent), -1, double.MaxValue);
            BoqTable table = new BoqTable(name, count, priceChangePercent, type);
            _tables.Add(table);
        }
        public void UpdateTable(long id, string name, int count, double priceChangePercent, BoqTableType type)
        {
            Guard.Against.OutOfRange(priceChangePercent, nameof(priceChangePercent), -1, double.MaxValue);
            BoqTable table = _tables.First(t => t.Id == id);
            table.UpdateTable(name, count, priceChangePercent, type);
        }

        public void DeleteTable(long id)
        {
            BoqTable? table = _tables.Find(t => t.Id == id);
            if (table != null)
            {
                _tables.Remove(table);
            }
        }
        public void AddSection(long tableId, string sectionName, Department department)
        {
            BoqTable table = _tables.First(t => t.Id == tableId);
            table.AddSection(sectionName, department);
        }
        public void UpdateSection(long tableId, long sectionId, string sectionName, Department department)
        {
            BoqTable table = _tables.First(t => t.Id == tableId);
            table.UpdateSection(sectionId, sectionName, department);
        }
        public void DeleteSection(long tableId, long sectionId)
        {
            BoqTable table = _tables.First(t => t.Id == tableId);
            table.DeleteSection(sectionId);
        }
        public void AddItem(long tableId, long sectionId, string index, string content, string unit, double quantity, double unitPrice)
        {
            BoqTable table = _tables.First(t => t.Id == tableId);
            table.AddItem(sectionId, index, content, unit, quantity, unitPrice);
        }
        public void UpdateItem(long tableId, long sectionId, long itemId, string index, string content, string unit, double quantity, double unitPrice)
        {
            BoqTable table = _tables.First(t => t.Id == tableId);
            table.UpdateItem(sectionId, itemId, index, content, unit, quantity, unitPrice);
        }
        public void DeleteItem(long tableId, long sectionId, long itemId)
        {
            BoqTable table = _tables.First(t => t.Id == tableId);
            table.DeleteItem(sectionId, itemId);
        }

    }
}
