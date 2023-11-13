using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;

namespace NUCA.Projects.Domain.Entities.Statements
{
    public class StatementItem : Entity<long>
    {
        // private List<StatementItemPercentage> _percentages = new List<StatementItemPercentage>();
        public long BoqItemId { get; private set; }
        public string Index { get; private set; }
        public string Content { get; private set; }
        public string Unit { get; private set; }
        public double Quantity { get; private set; }
        public double UnitPrice { get; private set; }
        public double TotalPrice => Quantity * UnitPrice;
        public double PreviousQuantity { get; private set; }
        public double CurrentQuantity => TotalQuantity - PreviousQuantity;
        public double TotalQuantity { get; private set; }
        public double GrossPrice => TotalQuantity * UnitPrice;
        public double Percentage { get; private set; }
        //public virtual IReadOnlyList<StatementItemPercentage> Percentages => _percentages.ToList();
        public double NetPrice => GrossPrice * Percentage;

        public string? Notes { get; private set; }
        public long? UserId { get; private set; }
        protected StatementItem() { }
        public StatementItem(long boqItemId, string index, string content, string unit, double quantity, double unitPrice, double previousQuantity, double totalQuantity,
            /*List<StatementItemPercentage> percentages,*/ double percentage, string? notes, long? userId)
        {
            BoqItemId = Guard.Against.NegativeOrZero(boqItemId);
            Index = Guard.Against.NullOrEmpty(index, nameof(index));
            Content = Guard.Against.NullOrEmpty(content, nameof(content));
            Unit = Guard.Against.NullOrEmpty(unit, nameof(unit));
            Quantity = Guard.Against.NegativeOrZero(quantity, nameof(quantity));
            UnitPrice = Guard.Against.NegativeOrZero(unitPrice, nameof(unitPrice));
            PreviousQuantity = Guard.Against.Negative(previousQuantity, nameof(previousQuantity));
            TotalQuantity = totalQuantity;
            Percentage = Guard.Against.OutOfRange(percentage, nameof(percentage), 0, 100);
            //_percentages = percentages;
            Notes = notes;
            UserId = userId;
            ValidatePercentages();
        }
        public void Update(StatementItemUpdates updates)
        {
            TotalQuantity = updates.TotalQuantity;
            Percentage = Guard.Against.OutOfRange(updates.Percentage, nameof(updates.Percentage), 0, 100);
            //_percentages = updates.Percentages;
            Notes = updates.Notes;
            UserId = updates.UserId;
            ValidatePercentages();
        }

        private void ValidatePercentages()
        {
            /* if (TotalQuantity != Percentages.Sum(p => p.Quantity))
             {
                 throw new ArgumentException("Not valid percentages");
             }*/
        }
        /* public void UpdateCurrentQuantity(double quantity, string userId) {
             TotalQuantity = quantity;
             UserId = userId;
         }
         public void UpdatePercentages(List<StatementItemPercentage> percentages, string userId)
         {
             _percentages = percentages;
             UserId = userId;
         }
         public void UpdateNotes(string notes, string userId)
         {
             Notes = notes;
             UserId = userId;
         }*/
    }
}
