using Ardalis.GuardClauses;
using System.Collections.Generic;
using System.Linq;

namespace NUCA.Identity.Domain
{
    public class UserGroup
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public CityAuthority CityAuthority { get; private set; }

        private List<User> _users = new();
        public virtual IReadOnlyList<User> Users => _users.ToList();

        private List<Role> _roles = new();
        public virtual IReadOnlyList<Role> Roles => _roles.ToList();

        protected UserGroup() { }
        public UserGroup(string name)
        {
            Name = Guard.Against.NullOrEmpty(name.Trim());
        }
    }
}
