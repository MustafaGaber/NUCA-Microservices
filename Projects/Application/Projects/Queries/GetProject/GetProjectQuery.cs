using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Application.Projects.Queries.Models;

namespace NUCA.Projects.Application.Projects.Queries.GetProject
{
    public class GetProjectQuery : IGetProjectQuery
    {
        private readonly IProjectRepository _repository;

        public GetProjectQuery(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetProjectModel> Execute(long id)
        {
            var project = await _repository.Get(id);
            return GetProjectModel.FromProject(project, false);
        }

    }
}


