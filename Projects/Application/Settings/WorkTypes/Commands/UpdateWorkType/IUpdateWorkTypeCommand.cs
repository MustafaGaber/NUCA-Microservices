using NUCA.Projects.Application.Settings.WorkTypes.Queries;

namespace NUCA.Projects.Application.Settings.WorkTypes.Commands.UpdateWorkType
{
    public interface IUpdateWorkTypeCommand
    {
        Task<GetWorkTypeModel> Execute(int id, WorkTypeModel model);
    }
}
