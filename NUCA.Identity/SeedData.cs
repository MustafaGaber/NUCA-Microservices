using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUCA.Identity.Data;
using NUCA.Identity.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NUCA.Identity
{
    public class SeedData
    {
        public static async Task EnsureSeedData(string connectionString)
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(connectionString));

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            using (var serviceProvider = services.BuildServiceProvider())
            {
                using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
                    context.Database.Migrate();
                    /*DepartmentPermission.AllPermissions.ForEach(permission =>
                    {
                        var existingPermission = context.DepartmentPermissions.FirstOrDefault(p => p.Id == permission.Id);
                        if (existingPermission == null)
                        {
                            context.DepartmentPermissions.Add(permission);
                        }
                    });
                    context.SaveChanges();*/
                    /*var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
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
                    });*/
                    var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                    var usersCount = await userMgr.Users.CountAsync();
                    if (usersCount == 0)
                    {
                        User superAdmin = new User("SuperAdmin", "Super Admin", "", "", new List<Enrollment> { }, new List<UserGroup> { });
                        await userMgr.CreateAsync(superAdmin, "Pass123$");
                        await userMgr.AddToRoleAsync(superAdmin, "superAdmin");
                    }
                }
            }
        }
    }
}
