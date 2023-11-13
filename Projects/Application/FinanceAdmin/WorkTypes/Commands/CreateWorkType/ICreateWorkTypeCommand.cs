using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Projects.Application.FinanceAdmin.WorkTypes.Commands.CreateWorkType
{
    public interface ICreateWorkTypeCommand
    {
        Task<WorkType> Execute(WorkTypeModel model);
    }
}
