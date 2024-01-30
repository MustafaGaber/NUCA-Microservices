namespace NUCA.Projects.Application.Settings.TaxAuthorities.Queries.GetTaxAuthorities
{
    public interface IGetTaxAuthoritiesQuery
    {
        Task<List<GetTaxAuthorityModel>> Execute();
    }
}
