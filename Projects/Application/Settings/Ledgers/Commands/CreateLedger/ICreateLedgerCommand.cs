using NUCA.Projects.Application.Settings.Ledgers.Models;

namespace NUCA.Projects.Application.Settings.Ledgers.Commands.CreateLedger
{
    public interface ICreateLedgerCommand
    {
        Task<GetLedgerModel> Execute(LedgerModel model);
    }
}
