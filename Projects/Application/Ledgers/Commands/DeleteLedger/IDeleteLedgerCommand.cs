namespace NUCA.Projects.Application.Ledgers.Commands.DeleteLedger
{
    public interface IDeleteLedgerCommand
    {
        Task Execute(long id);
    }
}
