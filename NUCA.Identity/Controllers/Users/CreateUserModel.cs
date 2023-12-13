using System.Collections.Generic;

namespace NUCA.Identity.Controllers.Users
{
    public class CreateUserModel
    {
        public string UserName { get; init; }
        public string FullName { get; init; }
        public string Password { get; init; }
        public List<int> DepartmentsIds { get; init; }

    }
}
