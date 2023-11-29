using System.Collections.Generic;

namespace NUCA.Projects.Application.Users.Commands
{
    public class UserModel
    {
        public string Name { get; init; }
        public List<int> DepartmentsIds { get; init; }
    }
}
