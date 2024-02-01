using NUCA.Projects.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Projects.Application.Companies.Queries.CanDeleteCompany
{
    class CanDeleteCompanyQuery : ICanDeleteCompanyQuery
    {
        private readonly ICompanyRepository _repository;
        public CanDeleteCompanyQuery(ICompanyRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Execute(long id)
        {
            var hasProjects = await _repository.CompanyHasProjects(id);
            return !hasProjects;
        }
    }
}
