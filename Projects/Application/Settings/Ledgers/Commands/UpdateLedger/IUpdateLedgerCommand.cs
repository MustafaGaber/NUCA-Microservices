using NUCA.Projects.Application.Settings.Ledgers.Models;

namespace NUCA.Projects.Application.Settings.Ledgers.Commands.UpdateLedger
{
    public interface IUpdateLedgerCommand
    {
        Task<GetLedgerModel> Execute(long id, LedgerModel model);
    }
}
