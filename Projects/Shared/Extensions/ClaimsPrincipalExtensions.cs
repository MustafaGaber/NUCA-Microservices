using System.Security.Claims;

namespace NUCA.Projects.Shared.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string? Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        public static List<string> Permissions(this ClaimsPrincipal user)
        {
            return user.FindAll(c => c.Type.Equals("permission"))
                                           .Select(c => c.Value).ToList(); 
        }
        public static bool HasPermission(this ClaimsPrincipal user, string permission)
        {
            return user.HasClaim(c => c.Type.Equals("permission") && c.Value.Equals(permission));
        }
    }
}
