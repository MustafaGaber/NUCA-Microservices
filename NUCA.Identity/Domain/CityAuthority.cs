using System.Collections.Generic;
using System.Linq;

namespace NUCA.Identity.Domain
{
    public class CityAuthority
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        private List<User> _users = new();
        public virtual IReadOnlyList<User> Users => _users.ToList();

    }
}
