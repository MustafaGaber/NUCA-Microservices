using NUCA.Identity.Domain;
using System.Collections.Generic;
using System.Linq;

namespace NUCA.Identity.Controllers.Users
{
    public class GetUserModel
    {
        public required string Id { get; init; }
        public required string FullName { get; init; }
        public required List<GetEnrollmentModel> Enrollments { get; init; }

        static public GetUserModel FromUser(User user)
        {
            return new GetUserModel
            {
                Id = user.Id,
                FullName = user.FullName,
                Enrollments = user.Enrollments.Select(e => new GetEnrollmentModel() { DepartmentId = e.Department.Id, DepartmentName = e.Department.Name, Role = e.Role }).ToList().ToList()
            };
        }
    }

    public class GetEnrollmentModel
    {
        public required int DepartmentId { get; init; }
        public required string DepartmentName { get; init; }
        public required EmployeeRole Role { get; init; }
    }
}
