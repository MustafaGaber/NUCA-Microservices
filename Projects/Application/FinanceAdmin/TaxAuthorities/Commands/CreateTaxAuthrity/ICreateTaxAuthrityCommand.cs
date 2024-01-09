using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Projects.Application.FinanceAdmin.TaxAuthorities.Commands.CreateTaxAuthority
{
    public interface ICreateTaxAuthorityCommand
    {
        Task<TaxAuthority> Execute(TaxAuthorityModel model);
    }
}
