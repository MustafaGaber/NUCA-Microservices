using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using NUCA.Identity.Domain;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;

namespace NUCA.Identity.Core
{
    public class ProfileService : IProfileService
    {

        private readonly UserManager<User> _userManager;

        public ProfileService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var serielizeOptions =  new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            User user = await _userManager.GetUserAsync(context.Subject);
            context.IssuedClaims.Add(new Claim("fullName", user.FullName));
            context.IssuedClaims.Add(new Claim("enrollments", JsonSerializer.Serialize(user.Enrollments.Select(e => new { departmentId = e.DepartmentId, departmentName = e.Department.Name, role = e.Job }), serielizeOptions)));
            foreach (var enrollment in user.Enrollments)
            {
                foreach (var permission in enrollment.Department.Permissions)
                {
                    context.IssuedClaims.Add(new Claim("permission", permission.Id));
                }
            }
            context.IssuedClaims.AddRange( user.Roles.Select(r => new Claim("role", r.Role.Name)));
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            User user = await _userManager.GetUserAsync(context.Subject);
            context.IsActive = user != null;
        }

    }
}
