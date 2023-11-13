
using NUCA.Projects.Application.Boqs.Models;

namespace NUCA.Projects.Application.Boqs.Commands.DeleteItem
{
    public interface IDeleteItemCommand
    {
        Task<BoqModel> Execute(long projectId, long tableId, long sectionId, long itemId);
    }
}
