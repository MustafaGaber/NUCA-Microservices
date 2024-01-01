using NUCA.Projects.Application.Boqs.Models;

namespace NUCA.Projects.Application.Boqs.Commands.UpdateSection
{
    public interface IUpdateSectionCommand
    {
        Task<BoqModel> Execute(long boqId, long tableId, long sectionId, UpdateSectionModel section);
    }
}
