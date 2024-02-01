using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NUCA.Identity.Data;
using NUCA.Identity.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NUCA.Identity.Core
{
    public class ApplicationUserStore : UserStore<User, Role, ApplicationDbContext,
        string, IdentityUserClaim<string>, UserRole, IdentityUserLogin<string>,
        IdentityUserToken<string>, IdentityRoleClaim<string>>
    {

        public ApplicationUserStore(ApplicationDbContext context, IdentityErrorDescriber describer = null) : base(context, describer) { }

        public override Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken = default)
        {
            return Users.FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
        }

        public override IQueryable<User> Users =>
               Context.Set<User>()
                      .Include(u => u.Enrollments).ThenInclude(e => e.Department)
                      .ThenInclude(d => d.Permissions)
                      .Include(u => u.Roles).ThenInclude(r => r.Role)
                      .Include(u => u.Groups).ThenInclude(g => g.Roles)
                      .Include(u => u.Authorities)
                      .AsSplitQuery();
    }


}
