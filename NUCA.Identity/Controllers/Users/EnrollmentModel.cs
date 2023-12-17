using NUCA.Identity.Domain;

namespace NUCA.Identity.Controllers.Users
{
    public class EnrollmentModel
    {
        public int DepartmentId { get; init; }
        public EmployeeRole Role { get; init; }
    }
}
