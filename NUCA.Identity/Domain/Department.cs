using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace NUCA.Identity.Domain
{
    public class Department 
    {
        private List<Enrollment> _enrollments = new List<Enrollment>();
        public virtual IReadOnlyList<Enrollment> Enrollments => _enrollments.ToList();
       
        private List<IdentityRole> _roles = new List<IdentityRole>();
        public virtual IReadOnlyList<IdentityRole> Roles => _roles.ToList();
        public int Id { get; private set; }
        public string Name { get; private set; }
        protected Department() { }
        public Department(string name, List<IdentityRole> roles)
        {
            Name = Guard.Against.NullOrEmpty(name.Trim());
            _roles = roles;
        }

        public void Update(string name, List<IdentityRole> roles)
        {
            Name = Guard.Against.NullOrEmpty(name.Trim());
            _roles.Clear();
            _roles.AddRange(roles);
        }
    }
}
