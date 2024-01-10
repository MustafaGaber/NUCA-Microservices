using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.Projects;

namespace NUCA.Projects.Domain.Entities.FinanceAdmin
{
    public class MainBank: Entity
    {
        public string Name { get; private set; }

        private readonly List<Bank> _branches = new();
        public virtual IReadOnlyList<Bank> Branches => _branches.ToList();
        protected MainBank() { }

        public MainBank(string name)
        {
            Name = Guard.Against.NullOrEmpty(name);
        }

        public void Update(string name)
        {
            Name = Guard.Against.NullOrEmpty(name);
        }
    }
}
