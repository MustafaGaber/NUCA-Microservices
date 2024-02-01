using NUCA.Projects.Application.Boqs.Models;

namespace NUCA.Projects.Application.Boqs.Commands.CreateItem
{
    public interface ICreateItemsCommand
    {
        Task<BoqModel> Execute(long boqId, long tableId, long sectionId, List<CreateItemModel> items);
    }
}
