namespace NUCA.Projects.Application.FinanceAdmin.TaxAuthorities.Queries.CanDeleteTaxAuthority
{
    public interface ICanDeleteTaxAuthorityQuery
    {
        Task<bool> Execute(int id);
    }
}
