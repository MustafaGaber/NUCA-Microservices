
using NUCA.Projects.Application.Boqs.Models;
namespace NUCA.Projects.Application.Boqs.Commands.DeleteSection
{
    public interface IDeleteSectionCommand
    {
        Task<BoqModel> Execute(long projectId, long tableId, long sectionId);
    }
}
