using NUCA.Identity.Domain;

namespace NUCA.Identity.Controllers.Users
{
    public class EnrollmentModel
    {
        public int DepartmentId { get; init; }
        public EnrollmentRole Role { get; init; }
    }
}
