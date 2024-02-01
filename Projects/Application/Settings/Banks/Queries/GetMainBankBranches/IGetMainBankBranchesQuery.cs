namespace NUCA.Projects.Application.Settings.Banks.Queries.GetMainBankBranches
{
    public interface IGetMainBankBranchesQuery
    {
        Task<List<GetBankBranchModel>> Execute(long id);
    }
}
