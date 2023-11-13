

using NUCA.Projects.Application.Boqs.Models;

namespace NUCA.Projects.Application.Boqs.Commands.DeleteTable
{
    public interface IDeleteTableCommand
    {
        Task<BoqModel> Execute(long projectId, long tableId);
    }
}
