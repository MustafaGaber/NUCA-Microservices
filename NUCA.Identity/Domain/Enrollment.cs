using Ardalis.GuardClauses;

namespace NUCA.Identity.Domain
{
    public class Enrollment
    {
        public string UserId { get; private set; }
        public int DepartmentId { get; private set; }
        public Department Department { get; private set; }
        public Job Job { get; private set; }
        protected Enrollment() { }
        public Enrollment(string userId, Department department, Job job)
        {
            UserId = Guard.Against.NullOrEmpty(userId);
            Department = Guard.Against.Null(department);
            DepartmentId = Guard.Against.NegativeOrZero(Department.DepartmentId);
            Job = job;
        }
    }
}
