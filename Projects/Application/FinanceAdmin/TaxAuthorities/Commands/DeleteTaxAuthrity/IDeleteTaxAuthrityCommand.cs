namespace NUCA.Projects.Application.FinanceAdmin.TaxAuthorities.Commands.DeleteTaxAuthority
{
    public interface IDeleteTaxAuthorityCommand
    {
        Task Execute(int id);
    }
}
