using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.Departments;
using NUCA.Projects.Domain.Entities.Settings;
using NUCA.Projects.Domain.Entities.Shared;
using System.Xml.Linq;

namespace NUCA.Projects.Domain.Entities.Boqs
{
    public class BoqTable : Entity
    {
        public long BoqId { get; private set; }

        private readonly List<BoqSection> _sections = new List<BoqSection>();
        public string Name { get; private set; }
        public int Count { get; private set; }
        public double PriceChangePercent { get; private set; }
        public BoqTableType Type { get; private set; }
        public WorkType WorkType { get; private set; }
        public long WorkTypeId { get; private set; }
        public bool IsPerformanceRate { get; private set; }
        public CostCenter CostCenter { get; private set; }
        public long CostCenterId { get; private set; }
        public bool Sovereign { get; private set; }
        public virtual IReadOnlyList<BoqSection> Sections => _sections.ToList();
        protected BoqTable() { }
        public BoqTable(
            long boqId,
            string name,
            int count,
            double priceChangePercent,
            BoqTableType type,
            WorkType workType,
            bool isPerformanceRate,
            CostCenter costCenter,
            bool sovereign)
        {
            BoqId = Guard.Against.NegativeOrZero(boqId);
            Name = name;
            Count = Guard.Against.NegativeOrZero(count, nameof(count));
            PriceChangePercent = Guard.Against.OutOfRange(priceChangePercent, nameof(priceChangePercent), -100, double.MaxValue);
            Type = Guard.Against.Null(type);
            BoqId = boqId;
            WorkType = Guard.Against.Null(workType);
            WorkTypeId = Guard.Against.NegativeOrZero(workType.Id);
            IsPerformanceRate = isPerformanceRate;
            CostCenter = Guard.Against.Null(costCenter);
            CostCenterId = Guard.Against.NegativeOrZero(costCenter.Id);
            Sovereign = sovereign;
        }
        internal void UpdateTable(
            string name,
            int count,
            double priceChangePercent,
            BoqTableType type,
            WorkType workType,
            bool isPerformanceRate,
            CostCenter costCenter,
            bool sovereign)
        {
            Name = name;
            Count = Guard.Against.NegativeOrZero(count, nameof(count));
            PriceChangePercent = Guard.Against.OutOfRange(priceChangePercent, nameof(priceChangePercent), -100, double.MaxValue);
            Type = Guard.Against.Null(type);
            WorkType = Guard.Against.Null(workType);
            IsPerformanceRate = isPerformanceRate;
            CostCenter = Guard.Against.Null(costCenter);
            Sovereign = sovereign;
        }
        internal void AddSection(
            string sectionName,
            string departmentId,
            string departmentName,
             WorkType workType,
            bool isPerformanceRate,
            CostCenter costCenter,
            bool sovereign)
        {
            _sections.Add(new BoqSection(
                name: sectionName,
                departmentId: departmentId,
                departmentName: departmentName,
                workType: workType,
                isPerformanceRate: isPerformanceRate,
                sovereign: sovereign,
                costCenter: costCenter
                ));
        }
        internal void UpdateSection(
            long id,
            string sectionName,
            string departmentId,
            string departmentName,
            WorkType workType,
            bool isPerformanceRate,
            CostCenter costCenter,
            bool sovereign
            )
        {
            BoqSection? section = _sections.Find(s => s.Id == id);
            section.Update(name: sectionName,
                departmentId: departmentId,
                departmentName: departmentName,
                workType: workType,
                isPerformanceRate: isPerformanceRate,
                sovereign: sovereign,
                costCenter: costCenter);
        }
        internal void DeleteSection(long id)
        {
            BoqSection? section = _sections.Find(s => s.Id == id);
            if (section != null)
            {
                _sections.Remove(section);
            }
        }
        internal void AddItem(long sectionId, string index, string content, string unit, double quantity, double unitPrice, WorkType workType, bool isPerformanceRate, bool sovereign, CostCenter costCenter)
        {
            BoqSection? section = _sections.Find(s => s.Id == sectionId);
            section.AddItem(index: index,
                content: content,
                unit: unit,
                quantity: quantity,
                unitPrice: unitPrice,
                workType: workType,
                isPerformanceRate: isPerformanceRate,
                sovereign: sovereign,
                costCenter: costCenter);
        }
        internal void UpdateItem(long sectionId, long itemId, string index, string content, string unit, double quantity, double unitPrice, WorkType workType, bool isPerformanceRate, bool sovereign, CostCenter costCenter)
        {
            BoqSection? section = _sections.Find(s => s.Id == sectionId);
            section.UpdateItem(
                id: itemId,
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
        internal void DeleteItem(long sectionId, long itemId)
        {
            BoqSection? section = _sections.Find(s => s.Id == sectionId);
            section.DeleteItem(itemId);
        }
    }
}
