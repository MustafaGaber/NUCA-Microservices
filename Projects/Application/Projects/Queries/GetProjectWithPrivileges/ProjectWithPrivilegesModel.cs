
using NUCA.Projects.Domain.Entities.Projects;

namespace NUCA.Projects.Application.Projects.Queries.GetProjectWithPrivileges
{
    public class ProjectWithPrivilegesModel
    {
        public required string Name { get; init; }
        public required string? CompanyName { get; init; }
        public required List<DepartmentModel> Departments { get; init; }
        public required List<PrivilegeModel> Privileges { get; init; }

    }

    public class DepartmentModel
    {
        public required string Id { get; init; }
        public required string Name { get; init; }
    }

    public class PrivilegeModel
    {
     //   public long Id { get; init; }
        public Guid? UserId { get; init; }
        public PrivilegeType Type { get; init; }
        public Guid? DepartmentId { get; init; }
    }
}
