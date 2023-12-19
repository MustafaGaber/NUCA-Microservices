using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NUCA.Identity.Domain
{
    public class Department 
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        private List<Enrollment> _enrollments = new List<Enrollment>();
        public virtual IReadOnlyList<Enrollment> Enrollments => _enrollments.ToList();
       
        private List<Permission> _permissions = new List<Permission>();
        public virtual IReadOnlyList<Permission> Permissions => _permissions.ToList();

        protected Department() { }
        public Department(string name, List<Permission> permissioins)
        {
            Name = Guard.Against.NullOrEmpty(name.Trim());
            _permissions = permissioins;
        }

        public void Update(string name, List<Permission> permissions)
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
