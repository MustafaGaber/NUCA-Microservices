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

        private List<UserGroup> _groups = new();
        public virtual IReadOnlyList<UserGroup> Groups => _groups.ToList();

        private List<UserRole> _roles = new();
        public virtual IReadOnlyList<UserRole> Roles => _roles.ToList();

        private List<CityAuthority> _authorities = new();
        public virtual IReadOnlyList<CityAuthority> CityAuthorities => _authorities.ToList();
        public string FullName { get; private set; }
        public string NationalId { get; private set; }
        public bool ShouldChangePassword { get; private set; }
        public User() { }
        public User(string userName, string fullName, string nationalId, string phone, List<Enrollment> enrollments, List<UserGroup> groups)
        {
            UserName = Guard.Against.NullOrWhiteSpace(userName.Trim());
            FullName = Guard.Against.NullOrWhiteSpace(fullName.Trim());
            NationalId = nationalId.Trim();
            PhoneNumber = phone.Trim();
            _enrollments = enrollments;
            _groups = groups;
            ShouldChangePassword = true;
        }

        public void Update(string fullName, string nationalId, string phone, List<Enrollment> enrollments, List<UserGroup> groups)
        {
            FullName = Guard.Against.NullOrWhiteSpace(fullName);
            NationalId = nationalId.Trim();
            PhoneNumber = phone.Trim();
            _enrollments = enrollments;
            _groups = groups;
        }

        public void SetShouldChangePassword(bool value)
        {
            ShouldChangePassword = value;
        }
    }
}
