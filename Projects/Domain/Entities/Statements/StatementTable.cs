﻿using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.Boqs;
using NUCA.Projects.Domain.Entities.Shared;

namespace NUCA.Projects.Domain.Entities.Statements
{
    public class StatementTable : Entity
    {
        private readonly List<StatementSection> _sections = new List<StatementSection>();
        public virtual IReadOnlyList<StatementSection> Sections => _sections.ToList();
        public long StatementId { get; private set; }
        public long BoqTableId { get; private set; }
        public string Name { get; private set; }
        public double PriceChangePercent { get; private set; }
        public StatementTableType Type { get; private set; }
        public BoqTableType BoqTableType { get; private set; }
        public long CostCenterId { get; private set; }
        public bool HasQuantities => _sections.Any(i => i.HasQuantities);

        protected StatementTable() { }
        public StatementTable(BoqTable boqTable, StatementTableType type, BoqTableType boqTableType, long costCenterId)
        {
            BoqTableId = Guard.Against.NegativeOrZero(boqTable.Id);
            Name = boqTable.Name;
            PriceChangePercent = Guard.Against.OutOfRange(boqTable.PriceChangePercent, nameof(boqTable.PriceChangePercent), -100, double.MaxValue);
            _sections = boqTable.Sections.Select(section => new StatementSection(section, boqTable.Count, type == StatementTableType.Supplies)).ToList();
            Type = Guard.Against.Null(type);
            BoqTableType = Guard.Against.Null(boqTableType);
            CostCenterId = costCenterId;

        }
        public StatementTable(BoqTable boqTable, StatementTable previousTable, StatementTableType type, BoqTableType boqTableType, long costCenterId)
        {
            BoqTableId = Guard.Against.NegativeOrZero(boqTable.Id);
            Name = boqTable.Name;
            PriceChangePercent = Guard.Against.OutOfRange(boqTable.PriceChangePercent, nameof(boqTable.PriceChangePercent), -100, double.MaxValue);
            _sections = boqTable.Sections.Select(section =>
            {
                var previousSection = previousTable.Sections.FirstOrDefault(s => s.BoqSectionId == section.Id);
                return previousSection == null ? new StatementSection(section, boqTable.Count, type == StatementTableType.Supplies) : new StatementSection(section, previousSection, boqTable.Count, type == StatementTableType.Supplies);
            }).ToList();
            Type = Guard.Against.Null(type);
            BoqTableType = Guard.Against.Null(boqTableType);
            CostCenterId = costCenterId;
        }
        public void UpdateItem(long sectionId, long itemId, double? previousQuantity, double totalQuantity, double percentage, List<PercentageDetail> percentageDetails, double? previousNetPrice)
        {
            StatementSection section = _sections.First(s => s.Id == sectionId);
            section.UpdateItem(
                itemId: itemId,
                previousQuantity: previousQuantity,
                totalQuantity: totalQuantity,
                percentage: percentage,
                percentageDetails: percentageDetails,
                previousNetPrice: previousNetPrice
            );
        }

        public double TotalBeforePriceChange => _sections.Sum(s => s.Total);
        public double Total
        {
            get
            {
                if (Type == StatementTableType.Supplies)
                    return TotalBeforePriceChange;
                else
                    return TotalBeforePriceChange * (100 + PriceChangePercent) / 100;
            }
        }
    }
}
