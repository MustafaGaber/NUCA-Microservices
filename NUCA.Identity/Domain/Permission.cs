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

        public static Permission GetById(string id)
        {
            return AllPermissions.First(r => r.Id == id);
        }

        public static readonly Permission Projects = new Permission("projects", "المشروعات");
        public static readonly Permission Execution = new Permission("execution", "التنفيذ");
        public static readonly Permission TechnicalOffice = new Permission("technicalOffice", "المكتب الفني");
        public static readonly Permission Revision = new Permission("revision", "المراجعة");
        public static readonly Permission Accounting = new Permission("accounting", "المالية");
       
        public static readonly List<Permission> AllPermissions = new List<Permission>()
        {
           Projects, Execution, TechnicalOffice, Revision, Accounting
        };
    }
}
