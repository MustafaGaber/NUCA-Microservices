using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;

namespace NUCA.Projects.Domain.Entities.FinanceAdmin
{
    public class TaxAuthority: Entity
    {
        public string Name { get; private set; }
        protected TaxAuthority() { }

        public TaxAuthority(string name)
        {
            Name = Guard.Against.NullOrEmpty(name);
        }

        public void Update(string name)
        {
            Name = Guard.Against.NullOrEmpty(name);
        }
    }
}
