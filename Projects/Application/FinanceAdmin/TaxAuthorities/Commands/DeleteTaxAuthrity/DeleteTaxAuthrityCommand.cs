using NUCA.Projects.Application.Interfaces.Persistence;

namespace NUCA.Projects.Application.FinanceAdmin.TaxAuthorities.Commands.DeleteTaxAuthority
{
    public class DeleteTaxAuthorityCommand : IDeleteTaxAuthorityCommand
    {
        private readonly ITaxAuthorityRepository _taxAuthorityRepository;
        public DeleteTaxAuthorityCommand(ITaxAuthorityRepository taxAuthorityRepository)
        {
            _taxAuthorityRepository = taxAuthorityRepository;
        }
        public async Task Execute(int id)
        {
            bool hasProjects = await _taxAuthorityRepository.TaxAuthorityHasProjects(id);
            if (!hasProjects)
            {
                await _taxAuthorityRepository.Delete(id);
            }
            else
            {
                throw new InvalidOperationException("TaxAuthority has projects");
            }
        }
    }
}
