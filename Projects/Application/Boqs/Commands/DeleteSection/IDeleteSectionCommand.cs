
using NUCA.Projects.Application.Boqs.Models;
namespace NUCA.Projects.Application.Boqs.Commands.DeleteSection
{
    public interface IDeleteSectionCommand
    {
        Task<BoqModel> Execute(long boqId, long tableId, long sectionId);
    }
}
