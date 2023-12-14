using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace NUCA.Identity.Domain
{
    public class User : IdentityUser
    {
        private readonly List<Department> _departments = new List<Department>();
        public virtual IReadOnlyList<Department> Departments => _departments.ToList();
        public string FullName { get; private set; }
        public string NationalId { get; private set; }

        public User() { }
        public User(string userName, string fullName, string nationalId, List<Department> departments) {
            UserName = Guard.Against.NullOrWhiteSpace(userName.Trim());
            FullName = Guard.Against.NullOrWhiteSpace(fullName.Trim());
            NationalId = Guard.Against.NullOrWhiteSpace(nationalId.Trim());
            _departments = departments;
        }

        public void Update(string fullName, string nationalId)
        {
            FullName = Guard.Against.NullOrWhiteSpace(fullName);
            NationalId = Guard.Against.NullOrWhiteSpace(nationalId);
        }
    }
}
