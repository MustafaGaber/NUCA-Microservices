using NUCA.Projects.Application.Interfaces.Persistence;

namespace NUCA.Projects.Application.Classifications.Commands.DeleteClassification
{
    public class DeleteClassificationCommand : IDeleteClassificationCommand
    {
        private readonly IClassificationRepository _repository;

        public DeleteClassificationCommand(IClassificationRepository repository)
        {
            _repository = repository;
        }
        public async Task Execute(long id)
        {
            await _repository.Delete(id);
        }
    }
}
