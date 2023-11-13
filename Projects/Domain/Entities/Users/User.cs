using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.Departments;

namespace NUCA.Projects.Domain.Entities.Users
{
    public class User : AggregateRoot<long>
    {
        private readonly List<Department> _departments = new List<Department>();
        public virtual IReadOnlyList<Department> Departments => _departments.ToList();
        public string Name { get; private set; }
        protected User() { }
        public User(string name, List<Department> departments)
        {
            Update(name, departments);
        }

        public void Update(string name, List<Department> departments)
        {
            Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
            _departments.Clear();
            _departments.AddRange(departments);
        }

    }
}
