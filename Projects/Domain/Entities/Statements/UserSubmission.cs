using Ardalis.GuardClauses;
using System.Runtime.CompilerServices;

namespace NUCA.Projects.Domain.Entities.Statements
{
    public class UserSubmission
    {
        public long Id { get; private set; }
        public string DepartmentId { get; private set; }
        public string UserId { get; private set; }
        public bool Approved { get; private set; }
        public string? Message { get; private set; }
        protected UserSubmission() { }

        public UserSubmission(string departmentId, string userId, bool approved, string? message = null)
        {
            DepartmentId = Guard.Against.NullOrEmpty(departmentId);
            UserId = Guard.Against.NullOrEmpty(userId);
            Approved = approved;
            Message = message;
        }
    }
}
