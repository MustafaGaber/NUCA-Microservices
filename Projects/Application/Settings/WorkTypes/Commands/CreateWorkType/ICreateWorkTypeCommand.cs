using NUCA.Projects.Application.Settings.WorkTypes.Queries;

namespace NUCA.Projects.Application.Settings.WorkTypes.Commands.CreateWorkType
{
    public interface ICreateWorkTypeCommand
    {
        Task<GetWorkTypeModel> Execute(WorkTypeModel model);
    }
}
