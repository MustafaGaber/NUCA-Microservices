using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace NUCA.Identity.Domain
{
    public class Role : IdentityRole
    {
        public string PublicName { get; private set; }

        private List<UserRole> _users = new();
        public virtual IReadOnlyList<UserRole> Users => _users.ToList();

        private List<UserGroup> _groups = new();
        public virtual IReadOnlyList<UserGroup> Groups => _groups.ToList();
        public Role(string name, string publicName)
        {
            Name = name;
            NormalizedName = name.ToUpper();
            PublicName = publicName;
        }

        public static Role Admin = new Role("admin", "مسؤل النظام");

        public static List<Role> AllRoles = new List<Role> { Admin };
    }
}

