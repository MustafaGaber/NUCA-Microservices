namespace NUCA.Projects.Application.Settings.TaxAuthorities.Queries.CanDeleteTaxAuthority
{
    public interface ICanDeleteTaxAuthorityQuery
    {
        Task<bool> Execute(int id);
    }
}
