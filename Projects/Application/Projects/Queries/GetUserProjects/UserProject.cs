using NUCA.Projects.Domain.Entities.Projects;

namespace NUCA.Projects.Application.Projects.Queries.GetUserProjects
{
    public class UserProject
    {
        public long Id { get; init; }
        public string Name { get; init; }
        public ProjectStatus Status { get; init; }
        public string? CompanyName { get; init; }

    }

}
