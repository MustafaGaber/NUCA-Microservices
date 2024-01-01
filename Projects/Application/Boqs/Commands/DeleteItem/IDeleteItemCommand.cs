
using NUCA.Projects.Application.Boqs.Models;

namespace NUCA.Projects.Application.Boqs.Commands.DeleteItem
{
    public interface IDeleteItemCommand
    {
        Task<BoqModel> Execute(long boqId, long tableId, long sectionId, long itemId);
    }
}
