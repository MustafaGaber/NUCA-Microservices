using NUCA.Projects.Domain.Entities.Projects;

namespace NUCA.Projects.Application.Projects.Commands.UpdatePrivileges
{
    public class UpdatePrivilegesModel
    {
       public required List<PrivilegeModel> Privileges { get; init; }
    }

    public class PrivilegeModel
    {
        public string? UserId { get; init; }
        public PrivilegeType Type { get; init; }
        public string? DepartmentId { get; init; }
    }
}
