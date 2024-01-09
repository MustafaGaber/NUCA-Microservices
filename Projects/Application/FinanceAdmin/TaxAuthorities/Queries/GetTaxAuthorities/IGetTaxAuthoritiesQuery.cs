namespace NUCA.Projects.Application.FinanceAdmin.TaxAuthorities.Queries.GetTaxAuthorities
{
    public interface IGetTaxAuthoritiesQuery
    {
        Task<List<GetTaxAuthorityModel>> Execute();
    }
}
