﻿using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;

namespace NUCA.Projects.Domain.Entities.Statements
{
    public class StatementItem : Entity<long>
    {
        private List<PercentageDetail> _percentageDetails = new List<PercentageDetail>();
        public long BoqItemId { get; private set; }
        public string Index { get; private set; }
        public string Content { get; private set; }
        public string Unit { get; private set; }
        public double BoqQuantity { get; private set; }
        public double UnitPrice { get; private set; }
        public double TotalBoqPrice => BoqQuantity * UnitPrice;
        public double PreviousQuantity { get; private set; }
        public double CurrentQuantity => TotalQuantity - PreviousQuantity;
        public double TotalQuantity { get; private set; }
        public double GrossPrice => TotalQuantity * UnitPrice;
        public double Percentage { get; private set; }
        public virtual IReadOnlyList<PercentageDetail> PercentageDetails => _percentageDetails.ToList();
        public double NetPrice => GrossPrice * Percentage / 100.0;
        public bool HasQuantities => !(PreviousQuantity == 0 && TotalQuantity == 0);
        protected StatementItem()
        {
            ValidatePercentage();
        }
        public StatementItem(long boqItemId, string index, string content, string unit, double quantity, double unitPrice, double previousQuantity, double totalQuantity,
             double percentage, List<PercentageDetail> percentageDetails)
        {
            BoqItemId = Guard.Against.NegativeOrZero(boqItemId);
            Index = Guard.Against.NullOrEmpty(index, nameof(index));
            Content = Guard.Against.NullOrEmpty(content, nameof(content));
            Unit = Guard.Against.NullOrEmpty(unit, nameof(unit));
            BoqQuantity = Guard.Against.NegativeOrZero(quantity, nameof(quantity));
            UnitPrice = Guard.Against.NegativeOrZero(unitPrice, nameof(unitPrice));
            PreviousQuantity = Guard.Against.Negative(previousQuantity, nameof(previousQuantity));
            TotalQuantity = totalQuantity;
            Percentage = Guard.Against.OutOfRange(percentage, nameof(percentage), 0, 100);
            _percentageDetails = percentageDetails;
            ValidatePercentage();
        }
        public void Update(UpdateStatementItemModel updates)
        {
            TotalQuantity = Guard.Against.Negative(updates.TotalQuantity);
            Percentage = Guard.Against.OutOfRange(updates.Percentage, nameof(updates.Percentage), 0, 100);
            _percentageDetails = updates.PercentageDetails?.Select(p => new PercentageDetail(p.Quantity, p.Percentage, p.Notes)).ToList() ?? new List<PercentageDetail> { };
            ValidatePercentage();
        }

        private void ValidatePercentage()
        {
            if (_percentageDetails.Count == 0) return;
            if (TotalQuantity != _percentageDetails.Sum(p => p.Quantity))
            {
                throw new ArgumentException("Invalid percentage");
            }
            double averagePercentage = _percentageDetails.Sum(p => p.Quantity * p.Percentage) / TotalQuantity;
            if (Math.Abs(Percentage - averagePercentage) > .00001)
            {
                throw new ArgumentException("Invalid percentage");
            }
        }

    }
}
