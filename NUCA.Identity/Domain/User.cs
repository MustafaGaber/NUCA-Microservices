using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace NUCA.Identity.Domain
{
    public class User : IdentityUser
    {
        private List<Enrollment> _enrollments = new List<Enrollment>();
        public virtual IReadOnlyList<Enrollment> Enrollments => _enrollments.ToList();
        public string FullName { get; private set; }
        public string NationalId { get; private set; }

        public User() { }
        public User(string userName, string fullName, string nationalId, List<Enrollment> enrollments) {
            UserName = Guard.Against.NullOrWhiteSpace(userName.Trim());
            FullName = Guard.Against.NullOrWhiteSpace(fullName.Trim());
            NationalId = Guard.Against.NullOrWhiteSpace(nationalId.Trim());
            _enrollments = enrollments;
        }

        public void Update(string fullName, string nationalId, List<Enrollment> enrollments)
        {
            FullName = Guard.Against.NullOrWhiteSpace(fullName);
            NationalId = Guard.Against.NullOrWhiteSpace(nationalId);
            _enrollments = enrollments;
        }
    }
}
