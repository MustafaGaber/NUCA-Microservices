namespace NUCA.Projects.Application.Settings.TaxAuthorities.Queries.GetTaxAuthority
{
    public interface IGetTaxAuthorityQuery
    {
        Task<GetTaxAuthorityModel?> Execute(int id);
    }
}
