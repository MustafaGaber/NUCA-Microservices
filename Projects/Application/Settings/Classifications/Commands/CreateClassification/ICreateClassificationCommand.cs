using NUCA.Projects.Application.Settings.Classifications.Commands;
using NUCA.Projects.Domain.Entities.Settings;

namespace NUCA.Projects.Application.Settings.Classifications.Commands.CreateClassification
{
    public interface ICreateClassificationCommand
    {
        Task<Classification> Execute(ClassificationModel model);
    }
}
