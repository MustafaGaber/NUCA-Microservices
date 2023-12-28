using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NUCA.Identity.Domain
{
    public class Department 
    {
        public string Id { get; private set; }
        public string Name { get; private set; }

        private List<Enrollment> _enrollments = new List<Enrollment>();
        public virtual IReadOnlyList<Enrollment> Enrollments => _enrollments.ToList();
       
        private List<DepartmentPermission> _permissions = new List<DepartmentPermission>();
        public virtual IReadOnlyList<DepartmentPermission> Permissions => _permissions.ToList();

        protected Department() { }
        public Department(string name, List<DepartmentPermission> permissioins)
        {
            Id =  Guid.NewGuid().ToString();
            Name = Guard.Against.NullOrEmpty(name.Trim());
            _permissions = permissioins;
        }

        public void Update(string name, List<DepartmentPermission> permissions)
        {
            Name = Guard.Against.NullOrEmpty(name.Trim());
           // _permissions = permissions;
            _permissions.RemoveAll(permission => !permissions.Any(p => p.Id == permission.Id));
            _permissions.AddRange(permissions.Where(permission => !_permissions.Any(p => p.Id == permission.Id)));

            /* _permissions.Clear();
             _permissions.AddRange(permissions);*/
        }
    }
}
