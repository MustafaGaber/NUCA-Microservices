using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Projects.Application.FinanceAdmin.WorkTypes.Commands.UpdateWorkType
{
    public interface IUpdateWorkTypeCommand
    {
        Task<WorkType> Execute(int id, WorkTypeModel model);
    }
}
