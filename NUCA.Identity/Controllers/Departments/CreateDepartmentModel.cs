

using System.Collections.Generic;

namespace NUCA.Identity.Controllers.Departments
{
    public class CreateDepartmentModel
    {
        public string Name { get; init; }
        public List<string> Permissions { get; set; }
    }
}
