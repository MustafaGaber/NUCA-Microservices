using NUCA.Projects.Domain.Common;

namespace NUCA.Projects.Domain.Entities.CostCenters
{
    public class CostCenter: Entity
    {
        public string Name { get; private set; }
        public CostCenter Parent { get; private set; }
        public long? ParentId { get; private set; }
        public List<CostCenter> Children { get; private set; }

    }
}
