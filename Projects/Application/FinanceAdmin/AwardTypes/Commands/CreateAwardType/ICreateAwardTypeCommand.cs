using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Projects.Application.FinanceAdmin.AwardTypes.Commands.CreateAwardType
{
    public interface ICreateAwardTypeCommand
    {
        Task<AwardType> Execute(AwardTypeModel model);
    }
}
