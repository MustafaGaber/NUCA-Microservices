using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Application.Projects.Models;
using NUCA.Projects.Shared.Extensions;
using System.Security.Claims;

namespace NUCA.Projects.Application.Projects.Queries.GetProjectLedgers
{
    public class GetProjectLedgersQuery : IGetProjectLedgersQuery
    {
        private readonly IProjectRepository _repository;
        private readonly IPrivilegeRepository _privilegeRepository;

        public GetProjectLedgersQuery(IProjectRepository repository, IPrivilegeRepository privilegeRepository)
        {
            _repository = repository;
            _privilegeRepository = privilegeRepository;
        }
        public async Task<GetProjectLedgersModel> Execute(long id, ClaimsPrincipal user)
        {
            if (user.Id() == null) throw new UnauthorizedAccessException();
            GetProjectLedgersModel project = await _repository.GetProjectLedgers(id);
            return project;
        }

    }
}
