using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Settings;


namespace NUCA.Projects.Application.Settings.Classifications.Commands.CreateClassification
{
    public class CreateClassificationCommand : ICreateClassificationCommand
    {
        private readonly IClassificationRepository _repository;

        public CreateClassificationCommand(IClassificationRepository repository)
        {
            _repository = repository;
        }

        public Task<Classification> Execute(ClassificationModel model)
        {
            return _repository.Add(new Classification(model.Name));
        }
    }
}
