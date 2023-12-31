using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace NUCA.Identity.Domain
{
    public class Role: IdentityRole
    {
        public string PublicName { get; private set; }
       
        private List<UserRole> _users = new List<UserRole>();
        public virtual IReadOnlyList<UserRole> Users => _users.ToList();
        public Role(string name, string publicName)
        {
            Name = name;
            PublicName = publicName;
        }

        //public static Role User = new Role("user", "مستخدم");
        public static Role Admin = new Role("admin", "مسؤل النظام");

        public static List<Role> AllRoles = new List<Role> { Admin };
    }
}

