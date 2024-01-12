namespace NUCA.Projects.Application.FinanceAdmin.Banks.Queries.GetMainBankBranches
{
    public interface IGetMainBankBranchesQuery
    {
        Task<List<GetBankBranchModel>> Execute(long id);
    }
}
