using NUCA.Projects.Application.Settings.Ledgers.Models;

namespace NUCA.Projects.Application.Settings.Ledgers.Queries.GetLedger
{
    public interface IGetLedgerQuery
    {
        Task<GetLedgerModel?> Execute(int id);
    }
}
