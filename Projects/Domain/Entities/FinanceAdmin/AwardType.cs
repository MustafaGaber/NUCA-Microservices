using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;

namespace NUCA.Projects.Domain.Entities.FinanceAdmin
{
    public class AwardType : Entity
    {
        public string Name { get; private set; }
        public bool EstimatedPrice { get; private set; }

        protected AwardType() { }

        public AwardType(string name, bool estimatedPrice)
        {
            Name = Guard.Against.NullOrEmpty(name, nameof(name));
            EstimatedPrice = estimatedPrice;
        }

        public void Update(string name, bool estimatedPrice)
        {
            Name = Guard.Against.NullOrEmpty(name, nameof(name));
            EstimatedPrice = estimatedPrice;
        }
    }
}
