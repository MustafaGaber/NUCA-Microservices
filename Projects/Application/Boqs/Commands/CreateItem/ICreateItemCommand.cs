using NUCA.Projects.Application.Boqs.Models;

namespace NUCA.Projects.Application.Boqs.Commands.CreateItem
{
    public interface ICreateItemCommand
    {
        Task<BoqModel> Execute(long projectId, long tableId, long sectionId, CreateItemModel item);
    }
}
