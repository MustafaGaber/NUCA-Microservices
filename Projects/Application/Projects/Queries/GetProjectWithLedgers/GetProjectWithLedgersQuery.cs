using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Application.Projects.Models;
using NUCA.Projects.Shared.Extensions;
using System.Security.Claims;

namespace NUCA.Projects.Application.Projects.Queries.GetProjectLedgers
{
    public class GetProjectWithLedgersQuery : IGetProjectWithLedgersQuery
    {
        private readonly IProjectRepository _repository;
        private readonly IPrivilegeRepository _privilegeRepository;

        public GetProjectWithLedgersQuery(IProjectRepository repository, IPrivilegeRepository privilegeRepository)
        {
            _repository = repository;
            _privilegeRepository = privilegeRepository;
        }
        public async Task<GetProjectWithLedgersModel> Execute(long id, ClaimsPrincipal user)
        {
            if (user.Id() == null) throw new UnauthorizedAccessException();
            GetProjectWithLedgersModel project = await _repository.GetProjectWithLedgers(id);
            return project;
        }

    }
}
