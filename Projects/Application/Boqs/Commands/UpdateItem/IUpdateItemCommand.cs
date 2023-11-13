using NUCA.Projects.Application.Boqs.Models;

namespace NUCA.Projects.Application.Boqs.Commands.UpdateItem
{
    public interface IUpdateItemCommand
    {
        Task<BoqModel> Execute(long projectId, long tableId, long sectionId, long itemId, UpdateItemModel item);
    }
}
