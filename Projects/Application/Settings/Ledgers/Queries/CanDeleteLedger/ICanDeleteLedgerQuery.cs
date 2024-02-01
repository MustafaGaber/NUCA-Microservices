namespace NUCA.Projects.Application.Settings.Ledgers.Queries.CanDeleteLedger
{
    public interface ICanDeleteLedgerQuery
    {
        Task<bool> Execute(long id);
    }
}
