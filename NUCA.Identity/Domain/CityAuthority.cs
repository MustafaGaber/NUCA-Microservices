using Ardalis.GuardClauses;
using System.Collections.Generic;
using System.Linq;

namespace NUCA.Identity.Domain
{
    public class CityAuthority
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        private List<User> _users = new();
        public virtual IReadOnlyList<User> Users => _users.ToList();

        public CityAuthority(string name)
        {
            Name = Guard.Against.NullOrEmpty(name);
        }
        internal void Update(string name)
        {
            Name = Guard.Against.NullOrEmpty(name);
        }
    }
}
