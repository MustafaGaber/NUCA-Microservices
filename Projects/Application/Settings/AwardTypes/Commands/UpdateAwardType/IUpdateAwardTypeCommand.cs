using NUCA.Projects.Domain.Entities.Settings;

namespace NUCA.Projects.Application.Settings.AwardTypes.Commands.UpdateAwardType
{
    public interface IUpdateAwardTypeCommand
    {
        Task<AwardType> Execute(int id, AwardTypeModel model);
    }
}
