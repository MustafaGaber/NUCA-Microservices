using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;

namespace NUCA.Projects.Domain.Entities.Settings
{
    public class Ledger : Entity
    {
        public string Name { get; private set; }
        public string? Code { get; private set; }
        public Ledger? Parent { get; private set; }
        public long? ParentId { get; private set; }
        public string? ParentFullPath { get; private set; }
        public string FullPath
        {
            get
            {
                if (ParentFullPath != null)
                {
                    return ParentFullPath + "/" + Id;
                }
                else
                {
                    return Id.ToString();
                }
            }
        }

        private readonly List<Ledger> _children = new();
        public virtual IReadOnlyList<Ledger> Children => _children.ToList();

        protected Ledger() { }
        public Ledger(string name, string? code, Ledger? parent)
        {
            Update(name, code, parent);
        }

        public void Update(string name, string? code, Ledger? parent)
        {
            Name = Guard.Against.NullOrEmpty(name.Trim());
            Code = code;
            Parent = parent;
            ParentId = parent?.Id;
            ParentFullPath = parent?.FullPath;
        }
    }
}
