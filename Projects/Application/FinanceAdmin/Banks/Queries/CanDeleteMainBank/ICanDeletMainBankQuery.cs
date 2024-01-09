namespace NUCA.Projects.Application.FinanceAdmin.MainBanks.Queries.CanDeleteMainBank
{
    public interface ICanDeleteMainBankQuery
    {
        Task<bool> Execute(int id);
    }
}
