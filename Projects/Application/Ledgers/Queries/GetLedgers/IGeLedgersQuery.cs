namespace NUCA.Projects.Application.Ledgers.Queries.GetLedgers
{
    public interface IGetLedgersQuery
    {
        Task<List<GetLedgerModel>> Execute();
    }
}
