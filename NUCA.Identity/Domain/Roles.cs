/*using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace NUCA.Identity.Domain
{
    public static class Permissions
    {
        public static readonly List<IdentityRole> AllPermissions = new List<IdentityRole>()
        {
            new IdentityRole("projects"),
            new IdentityRole("execution"),
            new IdentityRole("technicalOffice"),
            new IdentityRole("revision"),
            new IdentityRole("accounting"),
        };

        public static IdentityRole GetRole(string name)
        {
            return AllPermissions.First(r => r.Name == name);
        }


    }
}
*/