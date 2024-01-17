﻿using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.FinanceAdmin;
using NUCA.Projects.Domain.Entities.Shared;

namespace NUCA.Projects.Domain.Entities.Statements
{
    public class StatementItem : Entity
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
        public double NetPrice
        {
            get
            {
                if (IsPerformanceRate)
                {
                    return PreviousNetPrice + CurrentQuantity * UnitPrice * Percentage / 100;
                }
                else
                {
                    return GrossPrice * Percentage / 100.0;
                }
            }
        }

        public double PreviousNetPrice { get; private set; }
        public long WorkTypeId { get; private set; }
        public bool IsPerformanceRate { get; private set; }
        public long CostCenterId { get; private set; }
        public bool Sovereign { get; private set; }
        public bool HasQuantities => !(PreviousQuantity == 0 && TotalQuantity == 0);
        protected StatementItem()
        {
            ValidatePercentage();
        }
        public StatementItem(
            long boqItemId,
            string index,
            string content,
            string unit,
            double quantity,
            double unitPrice,
            long workTypeId,
            bool isPerformanceRate,
            long costCenterId,
            bool sovereign,
            double previousQuantity,
            double totalQuantity,
            double percentage,
            List<PercentageDetail> percentageDetails,
            double previousNetPrice)
        {
            BoqItemId = Guard.Against.NegativeOrZero(boqItemId);
            Index = Guard.Against.NullOrEmpty(index);
            Content = Guard.Against.NullOrEmpty(content);
            Unit = Guard.Against.NullOrEmpty(unit);
            BoqQuantity = Guard.Against.NegativeOrZero(quantity);
            UnitPrice = Guard.Against.NegativeOrZero(unitPrice);
            WorkTypeId = Guard.Against.NegativeOrZero(workTypeId);
            IsPerformanceRate = isPerformanceRate;
            CostCenterId = Guard.Against.NegativeOrZero(costCenterId);
            Sovereign = sovereign;
            PreviousQuantity = Guard.Against.Negative(previousQuantity, nameof(previousQuantity));
            TotalQuantity = totalQuantity;
            Percentage = Guard.Against.OutOfRange(percentage, nameof(percentage), 0, 100);
            _percentageDetails = percentageDetails;
            PreviousNetPrice = previousNetPrice;
            ValidatePercentage();
        }
        public void Update(UpdateStatementItemModel updates)
        {
            TotalQuantity = Guard.Against.Negative(updates.TotalQuantity);
            Percentage = Guard.Against.OutOfRange(updates.Percentage, nameof(updates.Percentage), 0, 100);
            _percentageDetails = updates.PercentageDetails.Select(p => new PercentageDetail(p.Quantity, p.Percentage, p.Notes)).ToList();
            /* _percentageDetails.RemoveAll(detail => !withholdings.Any(w => w.Id == withholding.Id));
             _percentageDetails.ForEach(w =>
             {
                 StatementWithholding? withholding = _withholdings.Find(_w => _w.Id == w.Id);
                 if (withholding != null)
                 {
                     withholding.Update(w.Name, w.Value, w.WorkType);
                 }
             });
             _percentageDetails.AddRange(withholdings.Where(w => w.Id == 0).Select(w => new StatementWithholding(w.Name, w.Value, w.WorkType)));

             */
            ValidatePercentage();
        }

        private void ValidatePercentage()
        {
            if (_percentageDetails.Count == 0) return;
            if (_percentageDetails.Count > 0 && IsPerformanceRate)
            {
                throw new ArgumentException("Invalid percentage");
            }
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
