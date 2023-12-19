using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.Departments;

namespace NUCA.Projects.Domain.Entities.Boqs
{
    public class BoqSection : Entity<long>
    {
        public long BoqId { get; private set; }

        private readonly List<BoqItem> _items = new List<BoqItem>();
        public string Name { get; private set; }
        public string DepartmentId { get; private set; }
        public string DepartmentName { get; private set; }
        public virtual IReadOnlyList<BoqItem> Items => _items.ToList();
        protected BoqSection() { }
        public BoqSection(long boqId, string name,  string departmentId, string departmentName)
        {
            BoqId = Guard.Against.NegativeOrZero(boqId);
            Name = name;
            DepartmentId = Guard.Against.NullOrEmpty(departmentId);
            DepartmentName = Guard.Against.NullOrEmpty(departmentName);
        }
        internal void Update(string name, string departmentId, string departmentName)
        {
            Name = name;
            DepartmentId = Guard.Against.NullOrEmpty(departmentId);
            DepartmentName = Guard.Against.NullOrEmpty(departmentName);
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
