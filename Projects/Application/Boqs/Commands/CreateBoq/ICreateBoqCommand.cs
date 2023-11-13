using NUCA.Projects.Application.Boqs.Models;

namespace NUCA.Projects.Application.Boqs.Commands.CreateBoq
{
    public interface ICreateBoqCommand
    {
        Task<BoqModel> Execute(long id, CreateBoqModel model);
    }
}
