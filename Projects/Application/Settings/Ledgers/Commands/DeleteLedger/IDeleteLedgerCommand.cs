namespace NUCA.Projects.Application.Settings.Ledgers.Commands.DeleteLedger
{
    public interface IDeleteLedgerCommand
    {
        Task Execute(long id);
    }
}
