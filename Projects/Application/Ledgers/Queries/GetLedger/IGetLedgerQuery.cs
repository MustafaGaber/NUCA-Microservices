namespace NUCA.Projects.Application.Ledgers.Queries.GetLedger
{
    public interface IGetLedgerQuery
    {
        Task<GetLedgerModel?> Execute(int id);
    }
}
