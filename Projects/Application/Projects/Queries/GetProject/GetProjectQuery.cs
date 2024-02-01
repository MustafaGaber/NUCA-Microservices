using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Application.Projects.Queries.Models;
using NUCA.Projects.Shared.Extensions;
using System.Security.Claims;

namespace NUCA.Projects.Application.Projects.Queries.GetProject
{
    public class GetProjectQuery : IGetProjectQuery
    {
        private readonly IProjectRepository _repository;
        private readonly IPrivilegeRepository _privilegeRepository;

        public GetProjectQuery(IProjectRepository repository, IPrivilegeRepository privilegeRepository)
        {
            _repository = repository;
            _privilegeRepository = privilegeRepository;
        }

        public async Task<GetProjectModel> Execute(long id, ClaimsPrincipal user)
        {
            if (user.Id() == null) throw new UnauthorizedAccessException();

            var project = await _repository.Get(id);
            return GetProjectModel.FromProject(project, false);
        }

    }
}


