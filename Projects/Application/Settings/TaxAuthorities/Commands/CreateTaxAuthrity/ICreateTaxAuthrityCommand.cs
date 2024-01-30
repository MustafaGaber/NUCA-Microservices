using NUCA.Projects.Domain.Entities.Settings;

namespace NUCA.Projects.Application.Settings.TaxAuthorities.Commands.CreateTaxAuthority
{
    public interface ICreateTaxAuthorityCommand
    {
        Task<TaxAuthority> Execute(TaxAuthorityModel model);
    }
}
