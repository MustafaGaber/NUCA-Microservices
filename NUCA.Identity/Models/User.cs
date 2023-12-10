using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace NUCA.Identity.Models
{
    public class User : IdentityUser
    {
        private readonly List<Department> _departments = new List<Department>();
        public virtual IReadOnlyList<Department> Departments => _departments.ToList();
        public string FullName { get; private set; }
        public string NationalId { get; private set; }

        protected User() { }
        public User(string fullName, string nationalId) {
            FullName = Guard.Against.NullOrWhiteSpace(fullName);
            NationalId = Guard.Against.NullOrWhiteSpace(nationalId);
        }

        public void Update(string fullName, string nationalId)
        {
            FullName = Guard.Against.NullOrWhiteSpace(fullName);
            NationalId = Guard.Against.NullOrWhiteSpace(nationalId);
        }
    }
}
