
namespace NUCA.Projects.Application.Projects.Queries.GetProjectWithDepartments
{
    public class ProjectWithDepartmentsModel
    {
        public required string Name { get; init; }
        public required string? CompanyName { get; init; }
        public required List<DepartmentModel> Departments { get; init; }
    }

    public class DepartmentModel
    {
        public required string Id { get; init; }
        public required string Name { get; init; }
    }
}
