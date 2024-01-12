namespace NUCA.Projects.Application.FinanceAdmin.Banks.Queries.CanDeleteMainBank
{
    public interface ICanDeleteMainBankQuery
    {
        Task<bool> Execute(long id);
    }
}
