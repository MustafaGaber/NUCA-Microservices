using NUCA.Projects.Domain.Entities.Settings;

namespace NUCA.Projects.Application.Interfaces.Persistence
{
    public interface IAwardTypeRepository : IRepository<AwardType>
    {
        public Task<bool> AwardTypeHasProjects(long id);
    }
}
