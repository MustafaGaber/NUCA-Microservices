using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Projects;

namespace NUCA.Projects.Application.Classifications.Commands.UpdateClassification
{
    public class UpdateClassificationCommand : IUpdateClassificationCommand
    {
        private readonly IClassificationRepository _repository;

        public UpdateClassificationCommand(IClassificationRepository repository)
        {
            _repository = repository;
        }
        public async Task<Classification> Execute(long id, ClassificationModel model)
        {
            Classification? classification = await _repository.Get(id) ?? throw new InvalidOperationException();
            classification.Update(model.Name);
            await _repository.Update(classification);
            return classification;
        }
    }
}
