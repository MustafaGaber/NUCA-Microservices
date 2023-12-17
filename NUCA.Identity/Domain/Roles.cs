using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace NUCA.Identity.Domain
{
    public static class Roles
    {
        public static readonly List<IdentityRole> AllRoles = new List<IdentityRole>()
        {
            new IdentityRole("projects"),
            new IdentityRole("execution"),
            new IdentityRole("technicalOffice"),
            new IdentityRole("revision"),
            new IdentityRole("accounting"),
        };

        public static IdentityRole GetRole(string name)
        {
            return AllRoles.First(r => r.Name == name);
        }


    }
}
