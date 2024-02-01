namespace NUCA.Projects.Application.Settings.Banks.Queries.CanDeleteMainBank
{
    public interface ICanDeleteMainBankQuery
    {
        Task<bool> Execute(long id);
    }
}
