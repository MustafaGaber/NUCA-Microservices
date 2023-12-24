using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;

namespace NUCA.Projects.Domain.Entities.Projects
{
    public class Privilege : Entity<long>
    {
        public Guid UserId { get; private set; }
        public PrivilegeType Type { get; private set; }
        public Guid? DepartmentId { get; private set; }

        public Privilege(Guid userId, PrivilegeType type, Guid? departmentId)
        {
            UserId =  Guard.Against.NullOrEmpty(userId);
            Type = type;
            DepartmentId = departmentId;
        }

        public void Update(Guid userId, PrivilegeType type, Guid? departmentId)
        {
            UserId = Guard.Against.NullOrEmpty(userId);
            Type = type;
            DepartmentId = departmentId;
        }
    }

}
