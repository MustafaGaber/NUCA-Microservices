/*using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Projects.Domain.Entities.Departments
{
    public class DepartmentGroup: Entity
    {
        public long DepartmentId { get; private set; }
        public long GroupId { get; private set; }
        public Department Department { get; private set; }
        public Group Group { get; private set; }
        protected DepartmentGroup() { }
        public DepartmentGroup(Department department, Group group)
        {
            Department = Guard.Against.Null(department, nameof(department));
            Group = Guard.Against.Null(group, nameof(group));
            DepartmentId = department.Id;
            GroupId = group.Id;
        }
    }
}
*/