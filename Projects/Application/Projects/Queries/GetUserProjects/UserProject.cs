using NUCA.Projects.Domain.Entities.Projects;

namespace NUCA.Projects.Application.Projects.Queries.GetUserProjects
{
    public class UserProject
    {
        public required long Id { get; init; }
        public required string Name { get; init; }
        public required ProjectStatus Status { get; init; }
        public required string? CompanyName { get; init; }
        public required List<PrivilegeModel> Privileges { get; init; }

    }

    public class PrivilegeModel
    {
        public required PrivilegeType Type { get; init; }
        public required string? DepartmentId { get; init; }
    }

}
