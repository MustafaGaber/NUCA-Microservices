using System.Collections.Generic;

namespace NUCA.Identity.Controllers.Users
{
    public class GetUserModel
    {
        public required string Id { get; init; }
        public required string FullName { get; init; }
        public required List<DepartmentModel> Departments { get; init; }
    }

    public class DepartmentModel
    {
        public required int Id { get; init; }
        public required string Name { get; init; }
    }
}
