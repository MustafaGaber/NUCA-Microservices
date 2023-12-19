﻿using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.Departments;
using NUCA.Projects.Domain.Entities.Shared;

namespace NUCA.Projects.Domain.Entities.Boqs
{
    public class BoqTable : Entity<long>
    {
        public long BoqId { get; private set; }

        private readonly List<BoqSection> _sections = new List<BoqSection>();
        public string Name { get; private set; }
        public int Count { get; private set; }
        public double PriceChangePercent { get; private set; }
        public BoqTableType Type { get; private set; }
        public virtual IReadOnlyList<BoqSection> Sections => _sections.ToList();
        protected BoqTable() { }
        public BoqTable(long boqId, string name, int count, double priceChangePercent, BoqTableType type)
        {
            BoqId = Guard.Against.NegativeOrZero(boqId);
            Name = name;
            Count = Guard.Against.NegativeOrZero(count, nameof(count));
            PriceChangePercent = Guard.Against.OutOfRange(priceChangePercent, nameof(priceChangePercent), -100, double.MaxValue);
            Type = Guard.Against.Null(type);
            BoqId = boqId;
        }
        internal void UpdateTable(string name, int count, double priceChangePercent, BoqTableType type)
        {
            Name = name;
            Count = Guard.Against.NegativeOrZero(count, nameof(count));
            PriceChangePercent = Guard.Against.OutOfRange(priceChangePercent, nameof(priceChangePercent), -100, double.MaxValue);
            Type = Guard.Against.Null(type);
        }
        internal void AddSection(string sectionName, string departmentId, string departmentName)
        {
            _sections.Add(new BoqSection(BoqId, sectionName, departmentId, departmentName));
        }
        internal void UpdateSection(long id, string sectionName, string departmentId, string departmentName)
        {
            BoqSection? section = _sections.Find(s => s.Id == id);
            section.Update(sectionName, departmentId, departmentName);
        }
        internal void DeleteSection(long id)
        {
            BoqSection? section = _sections.Find(s => s.Id == id);
            if (section != null)
            {
                _sections.Remove(section);
            }
        }
        internal void AddItem(long sectionId, string index, string content, string unit, double quantity, double unitPrice)
        {
            BoqSection? section = _sections.Find(s => s.Id == sectionId);
            section.AddItem(index, content, unit, quantity, unitPrice);
        }
        internal void UpdateItem(long sectionId, long itemId, string index, string content, string unit, double quantity, double unitPrice)
        {
            BoqSection? section = _sections.Find(s => s.Id == sectionId);
            section.UpdateItem(itemId, index, content, unit, quantity, unitPrice);
        }
        internal void DeleteItem(long sectionId, long itemId)
        {
            BoqSection? section = _sections.Find(s => s.Id == sectionId);
            section.DeleteItem(itemId);
        }
    }
}
