

using System.Collections.Generic;

namespace NUCA.Identity.Controllers.Departments
{
    public class GetDepartmentModel
    {
        public required int Id { get; init; }
        public required string Name { get; init; }
        public required List<PermissionModel> Permissions { get; init; }
    }
}
