using NUCA.Projects.Domain.Entities.Projects;

namespace NUCA.Projects.Application.Classifications.Commands.UpdateClassification
{
    public interface IUpdateClassificationCommand
    {
        Task<Classification> Execute(long id, ClassificationModel model);
    }
}
