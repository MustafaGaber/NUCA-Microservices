using NUCA.Projects.Domain.Entities.Settings;

namespace NUCA.Projects.Application.Settings.WorkTypes.Commands.CreateWorkType
{
    public interface ICreateWorkTypeCommand
    {
        Task<WorkType> Execute(WorkTypeModel model);
    }
}
