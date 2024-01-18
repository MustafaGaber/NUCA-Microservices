namespace NUCA.Projects.Application.Adjustments.Commands.CreateAdjustment
{
    public class CreateAdjustmentModel
    {
        public double? PreviousTotalWorks { get; init; }
        public double? PreviousTotalSupplies { get; init; }
        public bool Empty => !(PreviousTotalWorks.HasValue && PreviousTotalSupplies.HasValue);
    }
}
