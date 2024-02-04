namespace NUCA.Projects.Application.Settlements.Commands.CreateSettlement
{
    public class CreateSettlementModel
    {
        public double PreviousTotalWorks { get; init; }
        public double PreviousTotalSupplies { get; init; }
        public double TotalAdvancePaymentDeductions { get; init; }
        //public bool Empty => !(PreviousTotalWorks.HasValue && PreviousTotalSupplies.HasValue);
    }
}
