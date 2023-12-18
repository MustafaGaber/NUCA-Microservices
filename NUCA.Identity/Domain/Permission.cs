using System.Collections.Generic;
using System.Linq;

namespace NUCA.Identity.Domain
{
    public class Permission
    {
        public string Id { get; private set; }
        public string Name { get; private set; }

        public Permission(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public static readonly List<Permission> AllPermissions = new List<Permission>()
        {
            new Permission("projects", "المشروعات"),
            new Permission("execution", "التنفيذ"),
            new Permission("technicalOffice", "المكتب الفني"),
            new Permission("revision", "المراجعة"),
            new Permission("accounting", "المالية"),
        };

        public static Permission GetById(string id)
        {
            return AllPermissions.First(r => r.Id == id);
        }
    }
}
