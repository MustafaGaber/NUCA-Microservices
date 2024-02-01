using Microsoft.AspNetCore.Identity;

namespace NUCA.Identity.Domain
{
    public class UserRole : IdentityUserRole<string>
    {
        public UserRole() { }
        public virtual User User { get; private set; }
        public virtual Role Role { get; private set; }
    }
}
