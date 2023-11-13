/*using NUCA.Projects.Domain.Common;
using System.Collections.Generic;
using System.Linq;

namespace NUCA.Projects.Domain.Entities.Departments
{
    public class Group: Entity
    {
        private List<DepartmentGroup> _departments = new List<DepartmentGroup>();
        public virtual IReadOnlyList<DepartmentGroup> Departments => _departments.ToList();

        public string Name { get; private set; }
        protected Group() {}
        public Group(string name)
        {
            Name = name;
        }
    }
}
*/