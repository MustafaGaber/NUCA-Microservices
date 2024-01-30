namespace NUCA.Projects.Application.Settings.Banks.Queries
{
    public class GetBanksAndBranchesModel
    {
        public required List<GetMainBankModel> MainBanks { get; init; }
        public required List<GetBankBranchModel> Branches { get; init; }
    }
}
