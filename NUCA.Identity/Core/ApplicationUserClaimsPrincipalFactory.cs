/*using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using NUCA.Identity.Domain;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NUCA.Identity.Core
{
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<User>
    {
        public ApplicationUserClaimsPrincipalFactory(UserManager<User> userManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("FullName", user.FullName));
            foreach (var department in user.Enrollments){
                identity.AddClaim(new Claim("Department", department.Id.ToString()));
            }
            
            return identity;
        }
    }
}
*/