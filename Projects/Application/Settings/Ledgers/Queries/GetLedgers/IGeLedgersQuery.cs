using NUCA.Projects.Application.Settings.Ledgers.Models;

namespace NUCA.Projects.Application.Settings.Ledgers.Queries.GetLedgers
{
    public interface IGetLedgersQuery
    {
        Task<List<GetLedgerModel>> Execute();
    }
}
