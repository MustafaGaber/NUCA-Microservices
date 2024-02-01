using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.Projects;

namespace NUCA.Projects.Domain.Entities.Settings
{
    public class MainBank: Entity
    {
        public string Name { get; private set; }

        private readonly List<BankBranch> _branches = new();
        public virtual IReadOnlyList<BankBranch> Branches => _branches.ToList();
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
