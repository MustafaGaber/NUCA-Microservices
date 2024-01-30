

using NUCA.Identity.Domain;
using System.Collections.Generic;
using System.Linq;

namespace NUCA.Identity.Controllers.Departments
{
    public class GetDepartmentModel
    {
        public required string Id { get; init; }
        public required string Name { get; init; }
        public required List<PermissionModel> Permissions { get; init; }

        public static GetDepartmentModel FromDepartment(Department department)
        {
            return new GetDepartmentModel()
            {
                Id = department.DepartmentId.ToString(),
                Name = department.Name,
                Permissions = department.Permissions
                        .Select(p => new PermissionModel() { Id = p.Id, Name = p.Name })
                        .ToList()
            };
        }
    }
}
