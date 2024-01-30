using NUCA.Projects.Domain.Entities.Settings;

namespace NUCA.Projects.Application.Settings.WorkTypes.Commands.UpdateWorkType
{
    public interface IUpdateWorkTypeCommand
    {
        Task<WorkType> Execute(int id, WorkTypeModel model);
    }
}
