namespace NUCA.Projects.Application.FinanceAdmin.TaxAuthorities.Queries.GetTaxAuthority
{
    public interface IGetTaxAuthorityQuery
    {
        Task<GetTaxAuthorityModel?> Execute(int id);
    }
}
