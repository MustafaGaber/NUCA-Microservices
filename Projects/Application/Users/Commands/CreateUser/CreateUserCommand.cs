using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Departments;
using NUCA.Projects.Domain.Entities.Users;
using System.Collections.Generic;
using System.Linq;

namespace NUCA.Projects.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : ICreateUserCommand
    {
        private readonly IUserRepository _userRepository;
        private readonly IDepartmentRepository _departmentRepository;
        public CreateUserCommand(IUserRepository userRepository, IDepartmentRepository departmentRepository)
        {
            _userRepository = userRepository;
            _departmentRepository = departmentRepository;
        }
        public async Task<User> Execute(UserModel model)
        {
            List<Department> departments = await _departmentRepository.GetSome(model.DepartmentsIds);
            var user = await _userRepository.Add(new User(model.Name, departments));
            return user;
        }
    }
}
