using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;

namespace NUCA.Projects.Domain.Entities.FinanceAdmin
{
    public class TaxAuthority: Entity
    {
        public string Name { get; private set; }
        public string? Address { get; private set; }

        protected TaxAuthority() { }

        public TaxAuthority(string name, string address)
        {
            Name = Guard.Against.NullOrEmpty(name);
            Address = address;
        }

        public void Update(string name, string address)
        {
            Name = Guard.Against.NullOrEmpty(name);
            Address = address;
        }
    }
}
