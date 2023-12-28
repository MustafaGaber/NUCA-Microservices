using Ardalis.GuardClauses;
using System;

namespace NUCA.Identity.Domain
{
    public class Enrollment
    {
        public string UserId { get; private set; }
        public string DepartmentId { get; private set; }
        public Department Department { get; private set; }
        public EnrollmentRole Role { get; private set; }
        protected Enrollment() { }
        public Enrollment(string userId, Department department, EnrollmentRole role)
        {
            UserId = Guard.Against.NullOrWhiteSpace(userId);
            Department = Guard.Against.Null(department);
            DepartmentId = Guard.Against.NullOrEmpty(Department.Id);
            Role = role;
        }
    }
}
