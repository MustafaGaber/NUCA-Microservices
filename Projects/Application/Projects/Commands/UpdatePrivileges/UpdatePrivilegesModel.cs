using NUCA.Projects.Domain.Entities.Projects;

namespace NUCA.Projects.Application.Projects.Commands.UpdatePrivileges
{
    public class UpdatePrivilegesModel
    {
       public required List<PrivilegeModel> Privileges { get; init; }
    }

    public class PrivilegeModel
    {
        public PrivilegeModel() { 
            if  (DepartmentId != null && Type != PrivilegeType.Execution)
            {
                throw new ArgumentException();
            }
        }
        //  public long Id { get; init; }
        public Guid? UserId { get; init; }
        public PrivilegeType Type { get; init; }
        public Guid? DepartmentId { get; init; }
    }
}
