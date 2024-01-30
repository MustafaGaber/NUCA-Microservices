namespace NUCA.Projects.Application.Settings.Banks.Queries.GetBanksAndBranches
{
    public interface IGetBanksAndBranchesQuery
    {
        Task<GetBanksAndBranchesModel> Execute();

    }
}
