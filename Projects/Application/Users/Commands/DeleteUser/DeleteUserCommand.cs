using NUCA.Projects.Application.Interfaces.Persistence;

namespace NUCA.Projects.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand: IDeleteUserCommand
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserCommand(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task Execute(long id)
        {
            await _userRepository.Delete(id);
        }
    }
}
