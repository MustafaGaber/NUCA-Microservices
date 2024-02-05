using NUCA.Identity.Domain;
using System.Collections.Generic;
using System.Linq;

namespace NUCA.Identity.Controllers.Users
{
    public class GetUserModel
    {
        public required string Id { get; init; }
        public required string FullName { get; init; }
        public required string NationalId { get; init; }
        public required string PhoneNumber { get; init; }
        public required List<GetEnrollmentModel> Enrollments { get; init; }
        public required List<RoleModel> Roles { get; init; }
        public required List<GroupModel> Groups { get; init; }

        static public GetUserModel FromUser(User user)
        {
            return new GetUserModel
            {
                Id = user.Id,
                NationalId = user.NationalId,
                PhoneNumber = user.PhoneNumber,
                FullName = user.FullName,
                Enrollments = user.Enrollments.Select(e => new GetEnrollmentModel { DepartmentId = e.Department.Id.ToString(), DepartmentName = e.Department.Name, Job = e.Job }).ToList(),
                Roles = user.Roles.Select(r => new RoleModel { Name = r.Role.Name, PublicName = r.Role.PublicName }).ToList(),
                Groups = user.Groups.Select(r => new GroupModel { Id = 1/*r.Id*/, Name = r.Name }).ToList()
            };
        }
    }

    public class GetEnrollmentModel
    {
        public required string DepartmentId { get; init; }
        public required string DepartmentName { get; init; }
        public required Job Job { get; init; }
    }


    public class RoleModel
    {
        public required string Name { get; init; }
        public required string PublicName { get; init; }
    }

    public class GroupModel
    {
        public required int Id { get; init; }
        public required string Name { get; init; }
    }
}
