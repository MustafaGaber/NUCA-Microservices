using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.Users;

namespace NUCA.Projects.Domain.Entities.Departments
{
    public class Department : Entity
    {
        private readonly List<User> _users = new List<User>();
        public virtual IReadOnlyList<User> Users => _users.ToList();

        public string Name { get; private set; }
        protected Department() { }
        public Department(string name)
        {
            Name = Guard.Against.NullOrEmpty(name.Trim());
        }

        public void Update(string name)
        {
            Name = Guard.Against.NullOrEmpty(name.Trim());
        }
    }
}
