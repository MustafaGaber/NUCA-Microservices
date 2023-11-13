using NUCA.Projects.Domain.Entities.Projects;

namespace NUCA.Projects.Application.Projects.Queries.GetUserProjects
{
    public class UserProject
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ProjectStatus Status { get; set; }
        public string? CompanyName { get; set; }

    }

}
