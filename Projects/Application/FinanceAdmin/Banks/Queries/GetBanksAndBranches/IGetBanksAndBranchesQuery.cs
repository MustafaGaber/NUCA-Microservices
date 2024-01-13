namespace NUCA.Projects.Application.FinanceAdmin.Banks.Queries.GetBanksAndBranches
{
    public interface IGetBanksAndBranchesQuery
    {
        Task<GetBanksAndBranchesModel> Execute();

    }
}
