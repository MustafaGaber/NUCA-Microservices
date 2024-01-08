using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;

namespace NUCA.Projects.Domain.Entities.Projects
{
    public class Classification: Entity
    {
        public string Name { get; private set; }
       
        private readonly List<Project> _projects = new();
        public virtual IReadOnlyList<Project> Projects => _projects.ToList();
        protected Classification() { }
        public Classification(string name) {
            Name = Guard.Against.NullOrEmpty(name); 
        }
    }
}
