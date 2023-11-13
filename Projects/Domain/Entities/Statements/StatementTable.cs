using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.Boqs;
using NUCA.Projects.Domain.Entities.Shared;

namespace NUCA.Projects.Domain.Entities.Statements
{
    public class StatementTable : Entity<long>
    {
        protected readonly List<StatementSection> _sections = new List<StatementSection>();
        public long StatementId { get; private set; }
        public long BoqTableId { get; private set; }
        public string Name { get; private set; }
        public double PriceChangePercent { get; private set; }
        public StatementTableType Type { get; private set; }
        public BoqTableType BoqTableType { get; private set; }

        public virtual IReadOnlyList<StatementSection> Sections => _sections.ToList();
        protected StatementTable() { }
        public StatementTable(BoqTable boqTable, StatementTableType type, BoqTableType boqTableType)
        {
            BoqTableId = Guard.Against.NegativeOrZero(boqTable.Id);
            Name = boqTable.Name;
            PriceChangePercent = Guard.Against.OutOfRange(boqTable.PriceChangePercent, nameof(boqTable.PriceChangePercent), -100, double.MaxValue);
            _sections = boqTable.Sections.Select(section => new StatementSection(section, boqTable.Count)).ToList();
            Type = Guard.Against.Null(type);
            BoqTableType = Guard.Against.Null(boqTableType);
        }
        public StatementTable(BoqTable boqTable, StatementTable previousTable, StatementTableType type, BoqTableType boqTableType)
        {
            BoqTableId = Guard.Against.NegativeOrZero(boqTable.Id);
            Name = boqTable.Name;
            PriceChangePercent = Guard.Against.OutOfRange(boqTable.PriceChangePercent, nameof(boqTable.PriceChangePercent), -100, double.MaxValue);
            _sections = boqTable.Sections.Select(section => new StatementSection(section, previousTable.Sections.First(s => s.BoqSectionId == section.Id), boqTable.Count)).ToList();
            Type = Guard.Against.Null(type);
            BoqTableType = Guard.Against.Null(boqTableType);
        }
        public void UpdateItem(long sectionId, long itemId, StatementItemUpdates updates)
        {
            StatementSection section = _sections.First(s => s.Id == sectionId);
            section.UpdateItem(itemId, updates);
        }

        public double Total
        {
            get
            {
                if (Type == StatementTableType.Supplies)
                    return _sections.Sum(s => s.Total);
                else
                    return _sections.Sum(s => s.Total) * (100 + PriceChangePercent) / 100;
            }
        }
        /*public void UpdateCurrentQuantity(long sectionId, long itemId, double quantity, string userId)
        {
            StatementSection section = _sections.First(i => i.Id == sectionId);
            section.UpdateCurrentQuantity(itemId, quantity, userId);
        }
        public void UpdatePercentages(long sectionId, long itemId, List<StatementItemPercentage> percentages, string userId)
        {
            StatementSection section = _sections.First(i => i.Id == sectionId);
            section.UpdatePercentages(itemId, percentages, userId);
        }
        public void UpdateNotes(long sectionId, long itemId, string notes, string userId)
        {
            StatementSection section = _sections.First(i => i.Id == sectionId);
            section.UpdateNotes(itemId, notes, userId);
        }*/
    }
}
