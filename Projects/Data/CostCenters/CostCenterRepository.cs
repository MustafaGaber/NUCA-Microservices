using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Data.Shared;
using NUCA.Projects.Domain.Entities.CostCenters;

namespace NUCA.Projects.Data.CostCenters
{
    public class CostCenterRepository : Repository<CostCenter>, ICostCenterRepository
    {
        public CostCenterRepository(ProjectsDatabaseContext database) : base(database)
        {
        }
    }
}
