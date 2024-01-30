namespace NUCA.Projects.Application.Settings.Banks.Commands.DeleteMainBank
{
    public interface IDeleteMainBankCommand
    {
        Task Execute(long id);
    }
}
