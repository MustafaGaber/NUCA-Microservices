using Ardalis.GuardClauses;
using System.Collections.Generic;
using System.Linq;

namespace NUCA.Identity.Domain
{
    public class Department
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public DepartmentType Type { get; private set; }

        //public CityAuthority CityAuthority { get; private set; }

        private List<Enrollment> _enrollments = new List<Enrollment>();
        public virtual IReadOnlyList<Enrollment> Enrollments => _enrollments.ToList();

        private List<DepartmentPermission> _permissions = new();
        public virtual IReadOnlyList<DepartmentPermission> Permissions => _permissions.ToList();

        protected Department() { }

        public Department(int id, string name, DepartmentType type, List<DepartmentPermission> permissioins)
        {
            Id = id;
            Name = Guard.Against.NullOrEmpty(name.Trim());
            Type = Guard.Against.EnumOutOfRange(type);
            _permissions = permissioins;
        }
        public Department(string name, DepartmentType type, List<DepartmentPermission> permissioins)
        {
            Name = Guard.Against.NullOrEmpty(name.Trim());
            Type = Guard.Against.EnumOutOfRange(type);
            _permissions = permissioins;
        }

        public void Update(string name, DepartmentType type, List<DepartmentPermission> permissions)
        {
            Name = Guard.Against.NullOrEmpty(name.Trim());
            Type = Guard.Against.EnumOutOfRange(type);
            _permissions.RemoveAll(permission => !permissions.Any(p => p.Id == permission.Id));
            _permissions.AddRange(permissions.Where(permission => !_permissions.Any(p => p.Id == permission.Id)));
        }
    }
}
