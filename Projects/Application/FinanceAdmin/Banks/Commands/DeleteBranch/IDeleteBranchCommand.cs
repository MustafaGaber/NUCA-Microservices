namespace NUCA.Projects.Application.FinanceAdmin.Banks.Commands.DeleteBranch
{
    public interface IDeleteBranchCommand
    {
        Task Execute(long id);
    }
}
