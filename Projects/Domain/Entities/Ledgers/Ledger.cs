using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;

namespace NUCA.Projects.Domain.Entities.Ledgers
{
    public class Ledger: Entity
    {
        public string Name { get; private set; }
        public int Index { get; private set; }
        protected Ledger() { }
        public Ledger(string name, int index)
        {
            Name = Guard.Against.NullOrEmpty(name.Trim());
            Index = Guard.Against.NegativeOrZero(index);
        }

        public void Update(string name, int index)
        {
            Name = Guard.Against.NullOrEmpty(name.Trim());
            Index = Guard.Against.NegativeOrZero(index);
        }
    }
}
