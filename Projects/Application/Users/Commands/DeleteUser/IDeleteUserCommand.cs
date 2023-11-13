using NUCA.Projects.Domain.Common;

namespace NUCA.Projects.Application.Users.Commands.DeleteUser
{
    public interface IDeleteUserCommand
    {
        Task Execute(long id);
    }
}
