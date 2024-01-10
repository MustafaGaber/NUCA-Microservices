using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;

namespace NUCA.Projects.Domain.Entities.FinanceAdmin
{
    public class Bank: Entity
    {
        public string Name { get; private set; }
        public MainBank MainBank { get; private set; }
        protected Bank() { }

        public Bank(string name, MainBank mainBank)
        {
            Name = Guard.Against.NullOrEmpty(name);
            MainBank = mainBank;
        }

        public void Update(string name)
        {
            Name = Guard.Against.NullOrEmpty(name);
        }
    }
}
