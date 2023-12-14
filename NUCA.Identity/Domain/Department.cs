using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace NUCA.Identity.Domain
{
    public class Department 
    {
        private readonly List<User> _users = new List<User>();
        public virtual IReadOnlyList<User> Users => _users.ToList();
        public int Id { get; private set; }
        public string Name { get; private set; }
        public IdentityRole Role { get; private set; }
        protected Department() { }
        public Department(string name, IdentityRole role)
        {
            Name = Guard.Against.NullOrEmpty(name.Trim());
            Role = Guard.Against.Null(role);
        }

        public void Update(string name)
        {
            Name = Guard.Against.NullOrEmpty(name.Trim());
        }
    }
}
