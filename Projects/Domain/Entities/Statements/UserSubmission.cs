using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Entities.Projects;
using System.Runtime.CompilerServices;

namespace NUCA.Projects.Domain.Entities.Statements
{
    public class UserSubmission
    {
        public long Id { get; private set; }
        public string UserId { get; private set; }
        public PrivilegeType PrivilegeType { get; private set; }
        public string? DepartmentId { get; private set; }
        public bool Approved { get; private set; }
        public string? Message { get; private set; }

        protected UserSubmission() { }

        public UserSubmission(string userId, PrivilegeType privilegeType, string? departmentId, bool approved, string? message = null)
        {
            UserId = Guard.Against.NullOrEmpty(userId);
            PrivilegeType = privilegeType;
            DepartmentId = Guard.Against.NullOrEmpty(departmentId);
            Approved = approved;
            Message = message;
        }
    }
}
