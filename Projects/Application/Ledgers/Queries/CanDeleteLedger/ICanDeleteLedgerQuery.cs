namespace NUCA.Projects.Application.Ledgers.Queries.CanDeleteLedger
{
    public interface ICanDeleteLedgerQuery
    {
        Task<bool> Execute(int id);
    }
}
