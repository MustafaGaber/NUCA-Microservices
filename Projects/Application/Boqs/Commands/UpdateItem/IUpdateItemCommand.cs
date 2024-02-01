using NUCA.Projects.Application.Boqs.Models;

namespace NUCA.Projects.Application.Boqs.Commands.UpdateItem
{
    public interface IUpdateItemCommand
    {
        Task<BoqModel> Execute(long boqId, long tableId, long sectionId, long itemId, UpdateItemModel item);
    }
}
