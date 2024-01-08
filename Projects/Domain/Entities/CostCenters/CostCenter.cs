using NUCA.Projects.Domain.Common;

namespace NUCA.Projects.Domain.Entities.CostCenters
{
    public class CostCenter: Entity
    {
        public string Name { get; private set; }
        public CostCenter? Parent { get; private set; }
        public long? ParentId { get; private set; }
     
        private readonly List<CostCenter> _children = new();
        public virtual IReadOnlyList<CostCenter> Children => _children.ToList();

    }
}
