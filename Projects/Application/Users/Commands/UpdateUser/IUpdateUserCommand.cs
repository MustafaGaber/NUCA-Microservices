using NUCA.Projects.Domain.Entities.Users;

namespace NUCA.Projects.Application.Users.Commands.UpdateUser
{
    public interface IUpdateUserCommand
    {
        Task<User?> Execute(long id, UserModel model);
    }
}
