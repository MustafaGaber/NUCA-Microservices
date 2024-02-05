using System.Collections.Generic;
using System.Linq;

namespace NUCA.Identity.Domain
{
    public class DepartmentPermission
    {
        public string Id { get; private set; }
        public string Name { get; private set; }

        private List<Department> _departments = new();
        public virtual IReadOnlyList<Department> Departments => _departments.ToList();


        protected DepartmentPermission() { }
        public DepartmentPermission(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public static DepartmentPermission GetById(string id)
        {
            return AllPermissions.First(r => r.Id == id);
        }

        public static readonly DepartmentPermission Projects = new DepartmentPermission("projects", "المشروعات");
        public static readonly DepartmentPermission Execution = new DepartmentPermission("execution", "التنفيذ");
        public static readonly DepartmentPermission TechnicalOffice = new DepartmentPermission("technicalOffice", "المكتب الفني");
        public static readonly DepartmentPermission Revision = new DepartmentPermission("revision", "المراجعة");
        public static readonly DepartmentPermission Accounting = new DepartmentPermission("accounting", "الحسابات");
        public static readonly DepartmentPermission SeniorManagement = new DepartmentPermission("seniorManagement", "الإدارة العليا");


        public static readonly List<DepartmentPermission> AllPermissions = new List<DepartmentPermission>()
        {
           Projects, Execution, TechnicalOffice, Revision, Accounting, SeniorManagement
        };
    }
}
