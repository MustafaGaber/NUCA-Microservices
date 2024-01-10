using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.Departments;
using NUCA.Projects.Domain.Entities.FinanceAdmin;
using NUCA.Projects.Domain.Entities.Shared;

namespace NUCA.Projects.Domain.Entities.Boqs
{
    public class BoqSection : Entity
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
        internal void AddItem(string index, string content, string unit, double quantity, double unitPrice, WorkType workType, bool isPerformanceRate, bool sovereign, CostCenter costCenter)
        {
            _items.Add(new BoqItem(
                index: index,
                content: content,
                unit: unit,
                quantity: quantity,
                unitPrice: unitPrice,
                workType: workType,
                isPerformanceRate: isPerformanceRate,
                sovereign: sovereign,
                costCenter: costCenter));
        }
        internal void UpdateItem(long id, string index, string content, string unit, double quantity, double unitPrice, WorkType workType, bool isPerformanceRate, bool sovereign, CostCenter costCenter)
        {
            BoqItem item = _items.First(t => t.Id == id);
            item.Update(index: index,
                content: content,
                unit: unit,
                quantity: quantity,
                unitPrice: unitPrice,
                workType: workType,
                isPerformanceRate: isPerformanceRate,
                sovereign: sovereign,
                costCenter: costCenter);
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
