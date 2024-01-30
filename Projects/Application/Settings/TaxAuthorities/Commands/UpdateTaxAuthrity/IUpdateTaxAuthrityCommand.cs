using NUCA.Projects.Domain.Entities.Settings;

namespace NUCA.Projects.Application.Settings.TaxAuthorities.Commands.UpdateTaxAuthority
{
    public interface IUpdateTaxAuthorityCommand
    {
        Task<TaxAuthority> Execute(int id, TaxAuthorityModel model);
    }
}
