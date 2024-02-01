using NUCA.Projects.Domain.Common;

namespace NUCA.Projects.Application.Companies.Commands.DeleteCompany
{
    public interface IDeleteCompanyCommand
    {
        Task Execute(long id);
    }
}
