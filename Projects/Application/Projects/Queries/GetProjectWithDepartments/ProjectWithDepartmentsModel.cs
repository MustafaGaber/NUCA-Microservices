using NUCA.Projects.Domain.Entities.Projects;

namespace NUCA.Projects.Application.Projects.Queries.GetProjectWithDepartments
{
    public class ProjectWithDepartmentsModel
    {
        public required long Id { get; init; }
        public required string Name { get; init; }
        public required string? CompanyName { get; init; }
        public required List<string> Departments { get; init; }
    }
}
