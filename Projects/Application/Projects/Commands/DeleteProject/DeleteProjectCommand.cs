using NUCA.Projects.Application.Interfaces.Persistence;

namespace NUCA.Projects.Application.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommand : IDeleteProjectCommand
    {
        private readonly IProjectRepository _projectRepository;
        public DeleteProjectCommand(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task Execute(long id)
        {
            await _projectRepository.Delete(id);
        }
    }
}
