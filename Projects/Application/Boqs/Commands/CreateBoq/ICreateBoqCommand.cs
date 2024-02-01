using NUCA.Projects.Application.Boqs.Models;

namespace NUCA.Projects.Application.Boqs.Commands.CreateBoq
{
    public interface ICreateBoqCommand
    {
        Task<long> Execute(long projectId, CreateBoqModel model);
    }
}
