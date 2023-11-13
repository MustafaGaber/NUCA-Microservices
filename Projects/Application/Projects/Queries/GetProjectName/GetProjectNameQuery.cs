using NUCA.Projects.Application.Interfaces.Persistence;

namespace NUCA.Projects.Application.Projects.Queries.GetProjectName
{
    public class GetProjectNameQuery : IGetProjectNameQuery
    {
        private readonly IProjectRepository _repository;

        public GetProjectNameQuery(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Execute(long id)
        {
            string? name = await _repository.SelectOne(p => p.Id == id, p => p.Name);
            if (name == null)
            {
                throw new InvalidOperationException();
            }
            return name;
        }

    }
}


