using NUCA.Projects.Domain.Entities.Users;

namespace NUCA.Projects.Application.Users.Commands.CreateUser
{
    public interface ICreateUserCommand
    {
        Task<User> Execute(UserModel model);
    }
}
