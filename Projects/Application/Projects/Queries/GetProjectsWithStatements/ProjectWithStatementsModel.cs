using NUCA.Projects.Domain.Entities.Projects;

namespace NUCA.Projects.Application.Projects.Queries.GetProjectsWithStatements
{
    public class ProjectWithStatementsModel
    {
        public long Id { get; init; }
        public string Name { get; init; }
        public ProjectStatus Status { get; init; }
        public string? CompanyName { get; init; }
        public int StatementsCount { get; init; }
        public bool HasInProgressStatement { get; init; }
    }
}
