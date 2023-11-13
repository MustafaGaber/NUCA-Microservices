using NUCA.Projects.Domain.Entities.Projects;

namespace NUCA.Projects.Application.Projects.Queries.GetProjectsWithStatements
{
    public class ProjectWithStatements
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ProjectStatus Status { get; set; }
        public string? CompanyName { get; set; }
        public int StatementsCount { get; set; }
        public bool HasInProgressStatement { get; set; }
    }
}
