using Ardalis.GuardClauses;
using NUCA.Projects.Application.Statements.Models;
using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.CostCenters;
using NUCA.Projects.Domain.Entities.Departments;
using NUCA.Projects.Domain.Entities.FinanceAdmin;
using NUCA.Projects.Domain.Entities.Projects;
using NUCA.Projects.Domain.Entities.Shared;
using System.Reflection.Metadata;

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
        public void AddTable(string name, int count, double priceChangePercent, BoqTableType type)
        {
            Guard.Against.NegativeOrZero(count, nameof(count));
            Guard.Against.OutOfRange(priceChangePercent, nameof(priceChangePercent), -1, double.MaxValue);
            BoqTable table = new BoqTable(Id, name, count, priceChangePercent, type);
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
        public void AddSection(long tableId, string sectionName, string departmentId, string departmentName)
        {
            BoqTable table = _tables.First(t => t.Id == tableId);
            table.AddSection(sectionName, departmentId, departmentName);
        }
        public void UpdateSection(long tableId, long sectionId, string sectionName, string departmentId, string departmentName)
        {
            BoqTable table = _tables.First(t => t.Id == tableId);
            table.UpdateSection(sectionId, sectionName, departmentId, departmentName);
        }
        public void DeleteSection(long tableId, long sectionId)
        {
            BoqTable table = _tables.First(t => t.Id == tableId);
            table.DeleteSection(sectionId);
        }
        public void AddItem(long tableId, long sectionId, string index, string content, string unit, double quantity, double unitPrice, WorkType workType, CalculationMethod calculationMethod, bool sovereign, CostCenter costCenter)
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
                calculationMethod: calculationMethod,
                sovereign: sovereign,
                costCenter: costCenter);
        }
        public void UpdateItem(long tableId, long sectionId, long itemId, string index, string content, string unit, double quantity, double unitPrice, WorkType workType, CalculationMethod calculationMethod, bool sovereign, CostCenter costCenter)
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
                calculationMethod: calculationMethod,
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
