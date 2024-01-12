namespace NUCA.Projects.Application.FinanceAdmin.Banks.Queries
{
    public class GetBankBranchModel
    {
        public required long Id { get; init; }
        public required long MainBankId { get; init; }
        public required string Name { get; init; }
    }
}
