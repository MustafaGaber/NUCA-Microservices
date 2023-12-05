namespace NUCA.Projects.Domain.Entities.Statements
{
    public class StatementItemUpdates
    {
        public double TotalQuantity { get; private set; }
        // public List<PercentageDetail> PercentageDetails { get; private set; } = new List<PercentageDetail>();
        public double Percentage { get; private set; }
        public string Notes { get; private set; }
        public long UserId { get; private set; }
        public StatementItemUpdates(double totalQuantity,
            /*List<PercentageDetail> percentages, */
            double percentage,
            string notes, long userId)
        {
            TotalQuantity = totalQuantity;
            //PercentageDetails = percentages;
            Percentage = percentage;
            Notes = notes;
            UserId = userId;
        }
    }
}