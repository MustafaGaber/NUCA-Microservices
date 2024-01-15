using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.FinanceAdmin;
using NUCA.Projects.Domain.Entities.Projects;
using NUCA.Projects.Domain.Entities.Shared;


namespace NUCA.Projects.Domain.Entities.Boqs
{
    public class Boq : AggregateRoot
    {
        public long ProjectId { get; private set; }
        public Project Project { get; private set; } = null!;
        public double PriceChangePercent { get; private set; }
        public bool Approved { get; private set; }
        public string? ApprovedBy { get; private set; }
        
        private readonly List<BoqTable> _tables = new List<BoqTable>();
        public virtual IReadOnlyList<BoqTable> Tables => _tables.ToList();
       
        private readonly List<BoqDepartment> _departments = new();
        public virtual IReadOnlyList<BoqDepartment> Departments => _departments.ToList();

        protected Boq() { }
        public Boq(long projectId, double priceChangePercent)
        {
            ProjectId = Guard.Against.Null(projectId, nameof(projectId));
            PriceChangePercent = Guard.Against.OutOfRange(priceChangePercent, nameof(priceChangePercent), -100, double.MaxValue);
        }
        public void UpdateBoq(double priceChangePercent)
        {
            PriceChangePercent = Guard.Against.OutOfRange(priceChangePercent, nameof(priceChangePercent), -100, double.MaxValue);
        }
        public void AddTable(
            string name, 
            int count, 
            double priceChangePercent, 
            BoqTableType type,
            WorkType workType,
            bool isPerformanceRate,
            CostCenter costCenter,
            bool sovereign)
        {
            Guard.Against.NegativeOrZero(count, nameof(count));
            Guard.Against.OutOfRange(priceChangePercent, nameof(priceChangePercent), -1, double.MaxValue);
            BoqTable table = new BoqTable(
                boqId:Id, 
                name: name, 
                count: count,
                priceChangePercent: priceChangePercent, 
                type: type,
                workType: workType,
                isPerformanceRate: isPerformanceRate,
                costCenter: costCenter,
                sovereign: sovereign);
            _tables.Add(table);
        }
        public void UpdateTable(
            long id, 
            string name, 
            int count,
            double priceChangePercent,
            BoqTableType type,
            WorkType workType,
            bool isPerformanceRate,
            CostCenter costCenter,
            bool sovereign)
        {
            Guard.Against.OutOfRange(priceChangePercent, nameof(priceChangePercent), -1, double.MaxValue);
            BoqTable table = _tables.First(t => t.Id == id);
            table.UpdateTable(
                 name: name,
                count: count,
                priceChangePercent: priceChangePercent,
                type: type,
                workType: workType,
                isPerformanceRate: isPerformanceRate,
                costCenter: costCenter,
                sovereign: sovereign);
        }

        public void DeleteTable(long id)
        {
            BoqTable? table = _tables.Find(t => t.Id == id);
            if (table != null)
            {
                _tables.Remove(table);
            }
        }
        public void AddSection(
            long tableId, 
            string sectionName, 
            string departmentId, 
            string departmentName,
            WorkType workType,
            bool isPerformanceRate,
            CostCenter costCenter,
            bool sovereign)
        {
            BoqTable table = _tables.First(t => t.Id == tableId);
            table.AddSection(
                sectionName: sectionName,
                departmentId: departmentId,
                departmentName: departmentName,
                workType: workType,
                isPerformanceRate: isPerformanceRate,
                costCenter: costCenter,
                sovereign: sovereign);
            UpdateDepartments();
        }
        public void UpdateSection(
            long tableId, 
            long sectionId, 
            string sectionName, 
            string departmentId, 
            string departmentName,
            WorkType workType,
            bool isPerformanceRate,
            CostCenter costCenter,
            bool sovereign)
        {
            BoqTable table = _tables.First(t => t.Id == tableId);
            table.UpdateSection(
                id: sectionId,
                sectionName: sectionName,
                departmentId: departmentId,
                departmentName: departmentName,
                workType: workType,
                isPerformanceRate: isPerformanceRate,
                costCenter: costCenter,
                sovereign: sovereign);
            UpdateDepartments();
        }
        public void DeleteSection(long tableId, long sectionId)
        {
            BoqTable table = _tables.First(t => t.Id == tableId);
            table.DeleteSection(sectionId);
            UpdateDepartments();
        }

        private void UpdateDepartments()
        {
            var departments = _tables.Aggregate(
            new List<BoqDepartment> { },
            (departments, table) =>
                {
                    departments.AddRange(table.Sections.Select(s => new BoqDepartment {
                        DepartmentId= s.DepartmentId, 
                        DepartmentName = s.DepartmentName,
                        BoqId = Id
                    }));
                    return departments;
                }).Distinct().ToList();
            departments.ForEach(department =>
            {
                if (!_departments.Any(d => d.DepartmentId == department.DepartmentId && d.DepartmentName == department.DepartmentName))
                {
                    _departments.Add(department);
                }
            });
            _departments.ForEach(department =>
            {
                if (!departments.Any(d => d.DepartmentId == department.DepartmentId && d.DepartmentName == department.DepartmentName))
                {
                    _departments.Remove(department);
                }
            });
        }
        public void AddItem(long tableId, long sectionId, string index, string content, string unit, double quantity, double unitPrice, WorkType workType, bool isPerformanceRate, bool sovereign, CostCenter costCenter)
        {
            BoqTable table = _tables.First(t => t.Id == tableId);
            table.AddItem(
                sectionId: sectionId,
                index: index,
                content: content,
                unit: unit,
                quantity: quantity,
                unitPrice: unitPrice,
                workType: workType,
                isPerformanceRate: isPerformanceRate,
                sovereign: sovereign,
                costCenter: costCenter);
        }
        public void UpdateItem(long tableId, long sectionId, long itemId, string index, string content, string unit, double quantity, double unitPrice, WorkType workType, bool isPerformanceRate, bool sovereign, CostCenter costCenter)
        {
            BoqTable table = _tables.First(t => t.Id == tableId);
            table.UpdateItem(
                sectionId: sectionId,
                itemId: itemId,
                index: index,
                content: content,
                unit: unit,
                quantity: quantity,
                unitPrice: unitPrice,
                workType: workType,
                isPerformanceRate: isPerformanceRate,
                sovereign: sovereign,
                costCenter: costCenter);
        }
        public void DeleteItem(long tableId, long sectionId, long itemId)
        {
            BoqTable table = _tables.First(t => t.Id == tableId);
            table.DeleteItem(sectionId, itemId);
        }
        public void Approve(string userId)
        {
            Approved = true;
            ApprovedBy = userId;
        }
    }
}
