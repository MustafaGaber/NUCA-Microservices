
using System.Collections.Generic;

namespace NUCA.Projects.Application.Departments.Commands
{
    public class DepartmentModel
    {
        public string Name { get; init; }
        public List<long> GroupsIds { get; init; }
    }
}
