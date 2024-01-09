namespace NUCA.Projects.Application.FinanceAdmin.MainBanks.Commands.DeleteMainBank
{
    public interface IDeleteMainBankCommand
    {
        Task Execute(int id);
    }
}
