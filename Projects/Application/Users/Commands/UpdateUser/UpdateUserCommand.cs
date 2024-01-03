using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Departments;
using NUCA.Projects.Domain.Entities.Users;


namespace NUCA.Projects.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IUpdateUserCommand
    {
        private readonly IUserRepository _userRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public UpdateUserCommand(IUserRepository userRepository, IDepartmentRepository departmentRepository)
        {
            _userRepository = userRepository;
            _departmentRepository = departmentRepository;
        }
        public async Task<User?> Execute(long id, UserModel model)
        {
            List<Department> departments = await _departmentRepository.GetSome(model.DepartmentsIds);
            User? user = await _userRepository.Get(id) ?? throw new InvalidOperationException();
            user.Update(model.Name, departments);
            await _userRepository.Update(user);
            return user;
        }
    }
}
