using System.Collections.Generic;

namespace NUCA.Identity.Controllers.Users
{
    public class CreateUserModel
    {
        public string UserName { get; init; }
        public string FullName { get; init; }
        public string Password { get; init; }
        public string NationalId { get; init; }
        public string PhoneNumber { get; init; }
        public List<EnrollmentModel> Enrollments { get; init; }
        public List<string> Roles { get; init; } = new List<string> { };
        public List<int> Groups { get; init; } = new List<int> { };

    }
}
