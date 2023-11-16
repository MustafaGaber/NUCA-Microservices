using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace NUCA.Identity.Models
{
    public class User : IdentityUser
    {
        private readonly List<Department> _departments = new List<Department>();
        public virtual IReadOnlyList<Department> Departments => _departments.ToList();
        public string FullName { get; private set; }
    }
}
