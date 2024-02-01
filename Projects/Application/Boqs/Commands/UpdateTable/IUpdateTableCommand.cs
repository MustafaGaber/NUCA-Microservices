using NUCA.Projects.Application.Boqs.Models;

namespace NUCA.Projects.Application.Boqs.Commands.UpdateTable
{
    public interface IUpdateTableCommand
    {
        Task<BoqModel> Execute(long boqId, long tableId, UpdateTableModel table);
    }
}
