namespace NUCA.Projects.Application.FinanceAdmin.Banks.Queries
{
    public class GetBanksAndBranchesModel
    {
        public required List<GetMainBankModel> MainBanks { get; init; }
        public required List<GetBankBranchModel> Branches { get; init; }
    }
}
