using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.Departments;

namespace NUCA.Projects.Domain.Entities.Boqs
{
    public class BoqSection : Entity<long>
    {
        private readonly List<BoqItem> _items = new List<BoqItem>();
        public string Name { get; private set; }
        public virtual Department Department { get; private set; }
        public virtual IReadOnlyList<BoqItem> Items => _items.ToList();
        protected BoqSection() { }
        public BoqSection(string name, Department department)
        {
            Name = name;
            Department = Guard.Against.Null(department);
        }
        internal void Update(string newName, Department department)
        {
            Name = newName;
            Department = Guard.Against.Null(department);
        }
        internal void AddItem(string index, string content, string unit, double quantity, double unitPrice)
        {
            _items.Add(new BoqItem(index, content, unit, quantity, unitPrice));
        }
        internal void UpdateItem(long id, string index, string content, string unit, double quantity, double unitPrice)
        {
            BoqItem item = _items.First(t => t.Id == id);
            item.UpdateItem(index, content, unit, quantity, unitPrice);
        }
        internal void DeleteItem(long id)
        {
            BoqItem? item = _items.Find(s => s.Id == id);
            if (item != null)
            {
                _items.Remove(item);
            }
        }
    }
}
