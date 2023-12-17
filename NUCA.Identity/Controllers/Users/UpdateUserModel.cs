using NUCA.Identity.Domain;
using System.Collections.Generic;

namespace NUCA.Identity.Controllers.Users
{
    public class UpdateUserModel
    {
        public string FullName { get; init; }
        public List<EnrollmentModel> Enrollments { get; init; }
    }

}
