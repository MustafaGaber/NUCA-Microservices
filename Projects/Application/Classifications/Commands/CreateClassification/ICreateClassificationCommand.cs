using NUCA.Projects.Domain.Entities.Projects;

namespace NUCA.Projects.Application.Classifications.Commands.CreateClassification
{
    public interface ICreateClassificationCommand
    {
        Task<Classification> Execute(ClassificationModel model);
    }
}
