using NUCA.Projects.Domain.Entities.Projects;

namespace NUCA.Projects.Application.Projects.Commands.UpdatePrivileges
{
    public class UpdatePrivilegesModel
    {
       public required List<PrivilegeModel> Privileges { get; init; }
    }
}
