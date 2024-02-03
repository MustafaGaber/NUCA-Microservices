namespace NUCA.Projects.Application.Projects.Commands.UpdateLedgers
{
    public class UpdateLedgersModel
    {
        public long FromLedgerId { get; init; }
        public long ToLedgerId { get; init; }
        public long AdvancePaymentLedgerId { get; init; }
    }
}
