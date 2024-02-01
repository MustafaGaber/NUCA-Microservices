namespace NUCA.Projects.Application.Settings.TaxAuthorities.Commands.DeleteTaxAuthority
{
    public interface IDeleteTaxAuthorityCommand
    {
        Task Execute(int id);
    }
}
