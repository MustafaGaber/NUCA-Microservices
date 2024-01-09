using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Data.Ledgers;
using NUCA.Projects.Domain.Entities.Ledgers;
using NUCA.Projects.Domain.Entities.Projects;

namespace NUCA.Projects.Application.Classifications.Commands.CreateClassification
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
