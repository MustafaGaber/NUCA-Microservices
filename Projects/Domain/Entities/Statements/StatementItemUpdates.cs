namespace NUCA.Projects.Domain.Entities.Statements
{
    public class StatementItemUpdates
    {
        public double TotalQuantity { get; private set; }
        // public List<StatementItemPercentage> Percentages { get; private set; } = new List<StatementItemPercentage>();
        public double Percentage { get; private set; }
        public string Notes { get; private set; }
        public long UserId { get; private set; }
        public StatementItemUpdates(double totalQuantity,
            /*List<StatementItemPercentage> percentages, */
            double percentage,
            string notes, long userId)
        {
            TotalQuantity = totalQuantity;
            //Percentages = percentages;
            Percentage = percentage;
            Notes = notes;
            UserId = userId;
        }
    }
}