using NUCA.Projects.Application.Settings.Classifications.Commands;
using NUCA.Projects.Domain.Entities.Settings;

namespace NUCA.Projects.Application.Settings.Classifications.Commands.UpdateClassification
{
    public interface IUpdateClassificationCommand
    {
        Task<Classification> Execute(long id, ClassificationModel model);
    }
}
