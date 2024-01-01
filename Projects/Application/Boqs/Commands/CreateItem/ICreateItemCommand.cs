using NUCA.Projects.Application.Boqs.Models;

namespace NUCA.Projects.Application.Boqs.Commands.CreateItem
{
    public interface ICreateItemCommand
    {
        Task<BoqModel> Execute(long boqId, long tableId, long sectionId, CreateItemModel item);
    }
}
