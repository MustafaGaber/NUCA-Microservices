using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Projects.Application.FinanceAdmin.TaxAuthorities.Commands.UpdateTaxAuthority
{
    public interface IUpdateTaxAuthorityCommand
    {
        Task<TaxAuthority> Execute(int id, TaxAuthorityModel model);
    }
}
