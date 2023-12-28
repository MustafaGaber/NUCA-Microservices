using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUCA.Identity.Data;
using NUCA.Identity.Domain;
using System.Data;
using System.Linq;

namespace NUCA.Identity
{
    public class SeedData
    {
        public static async void EnsureSeedData(string connectionString)
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlite(connectionString));

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            using (var serviceProvider = services.BuildServiceProvider())
            {
                using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
                    context.Database.Migrate();
                    DepartmentPermission.AllPermissions.ForEach(permission =>
                    {
                        var existingPermission = context.DepartmentPermissions.FirstOrDefault(p => p.Id == permission.Id);
                        if (existingPermission == null)
                        {
                            context.DepartmentPermissions.Add(permission);
                        }
                    });
                    context.SaveChanges();
                    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
                    if (!await roleManager.RoleExistsAsync("superAdmin"))
                    {
                        await roleManager.CreateAsync(new Role("superAdmin", "مدير النظام"));
                    }
                    Role.AllRoles.ForEach(async role =>
                    {
                        if (!await roleManager.RoleExistsAsync(role.Name))
                        {
                           await roleManager.CreateAsync(role);
                        }
                    });
                    /*var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                    var alice = userMgr.FindByNameAsync("alice").Result;
                    if (alice == null)
                    {
                        alice = new User("test", "Test", "Test", new List<Enrollment>())
                        {
                            UserName = "alice",
                            Email = "AliceSmith@email.com",
                            EmailConfirmed = true,
                        };
                        var result = userMgr.CreateAsync(alice, "Pass123$").Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }

                        result = userMgr.AddClaimsAsync(alice, new Claim[]{
                            new Claim(JwtClaimTypes.PublicName, "Alice Smith"),
                            new Claim(JwtClaimTypes.GivenName, "Alice"),
                            new Claim(JwtClaimTypes.FamilyName, "Smith"),
                            new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                        }).Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }
                        Log.Debug("alice created");
                    }
                    else
                    {
                        Log.Debug("alice already exists");
                    }*/
                }
            }
        }
    }
}
