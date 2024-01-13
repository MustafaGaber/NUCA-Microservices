namespace NUCA.Projects.Application.FinanceAdmin.Banks.Queries.CanDeleteBranch
{
    public interface ICanDeleteBranchQuery
    {
        Task<bool> Execute(long id);
    }
}
