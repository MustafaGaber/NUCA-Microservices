using NUCA.Projects.Domain.Entities.Settings;

namespace NUCA.Projects.Application.Settings.AwardTypes.Commands.CreateAwardType
{
    public interface ICreateAwardTypeCommand
    {
        Task<AwardType> Execute(AwardTypeModel model);
    }
}
