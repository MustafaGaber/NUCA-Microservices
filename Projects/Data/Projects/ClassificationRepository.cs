using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Data.Shared;
using NUCA.Projects.Domain.Entities.Projects;

namespace NUCA.Projects.Data.Projects
{
    public class ClassificationRepository : Repository<Classification>, IClassificationRepository
    {
        public ClassificationRepository(ProjectsDatabaseContext database) : base(database)
        {
        }
    }
}
