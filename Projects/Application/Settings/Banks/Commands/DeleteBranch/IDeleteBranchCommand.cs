namespace NUCA.Projects.Application.Settings.Banks.Commands.DeleteBranch
{
    public interface IDeleteBranchCommand
    {
        Task Execute(long id);
    }
}
