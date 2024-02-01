namespace NUCA.Projects.Application.Settings.Banks.Queries.CanDeleteBranch
{
    public interface ICanDeleteBranchQuery
    {
        Task<bool> Execute(long id);
    }
}
