using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Projects.Application.FinanceAdmin.AwardTypes.Commands.UpdateAwardType
{
    public interface IUpdateAwardTypeCommand
    {
        Task<AwardType> Execute(int id, AwardTypeModel model);
    }
}
