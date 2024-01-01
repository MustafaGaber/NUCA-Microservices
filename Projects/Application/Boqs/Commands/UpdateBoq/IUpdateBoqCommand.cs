using NUCA.Projects.Application.Boqs.Models;

namespace NUCA.Projects.Application.Boqs.Commands.UpdateBoq
{
    public interface IUpdateBoqCommand
    {
        Task<BoqModel> Execute(long boqId, UpdateBoqModel model);
    }
}
