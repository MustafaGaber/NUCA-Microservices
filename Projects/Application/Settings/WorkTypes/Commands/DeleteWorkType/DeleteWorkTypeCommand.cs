using NUCA.Projects.Application.Interfaces.Persistence;

namespace NUCA.Projects.Application.Settings.WorkTypes.Commands.DeleteWorkType
{
    public class DeleteWorkTypeCommand : IDeleteWorkTypeCommand
    {
        private readonly IWorkTypeRepository _workTypeRepository;
        public DeleteWorkTypeCommand(IWorkTypeRepository workTypeRepository)
        {
            _workTypeRepository = workTypeRepository;
        }
        public async Task Execute(int id)
        {
            bool hasProjects = await _workTypeRepository.WorkTypeHasProjects(id);
            if (!hasProjects)
            {
                await _workTypeRepository.Delete(id);
            }
            else
            {
                throw new InvalidOperationException("WorkType has projects");
            }
        }
    }
}
