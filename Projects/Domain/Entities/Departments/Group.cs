/*using NUCA.Projects.Domain.Common;
using System.Collections.Generic;
using System.Linq;

namespace NUCA.Projects.Domain.Entities.ExecutionDepartments
{
    public class Group: Entity
    {
        private List<DepartmentGroup> _departments = new List<DepartmentGroup>();
        public virtual IReadOnlyList<DepartmentGroup> ExecutionDepartments => _departments.ToList();

        public string Name { get; private set; }
        protected Group() {}
        public Group(string name)
        {
            Name = name;
        }
    }
}
*/