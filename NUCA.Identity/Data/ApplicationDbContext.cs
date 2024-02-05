
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NUCA.Identity.Domain;


namespace NUCA.Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, string, IdentityUserClaim<string>,
    UserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        IPasswordHasher<User> _passwordHasher;
        public ApplicationDbContext(DbContextOptions options, IPasswordHasher<User> passwordHasher) : base(options)
        {
            _passwordHasher = passwordHasher;
        }

        public DbSet<Department> Departments { get; private set; }
        public DbSet<Enrollment> Enrollments { get; private set; }
        public DbSet<DepartmentPermission> DepartmentPermissions { get; private set; }
        public DbSet<UserGroup> UserGroups { get; private set; }

        public DbSet<CityAuthority> CityAuthorities { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Todo: turn off in production
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* builder.Entity<CityAuthority>()
                   .HasMany(c => c.Departments)
                   .WithOne(d => d.CityAuthority)
                   .IsRequired();*/

            /*builder.Entity<CityAuthority>()
                 .HasMany(c => c.UserGroups)
                 .WithOne(g => g.CityAuthority)
                 .IsRequired();*/

            builder.Entity<CityAuthority>()
                 .HasMany(c => c.Users)
                 .WithMany(u => u.CityAuthorities);

            builder.Entity<Department>()
                   .HasMany(d => d.Permissions)
                   .WithMany(p => p.Departments);

            builder.Entity<Department>()
                   .HasMany(d => d.Enrollments)
                   .WithOne(e => e.Department)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<User>()
                   .HasMany(u => u.Enrollments)
                   .WithOne()
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            // builder.Entity<User>().HasIndex(u => u.NationalId).IsUnique();

            builder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.Users)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(u => u.Roles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });


            builder.Entity<Enrollment>()
                   .HasKey(e => new { e.DepartmentId, e.UserId, e.Job });

            DepartmentPermission.AllPermissions.ForEach(permission =>
            {
                builder.Entity<DepartmentPermission>().HasData(permission);
            });
            builder.Entity<Role>().HasData(
                new
                {
                    Id = "superAdmin",
                    Name = "superAdmin",
                    NormalizedName = "SUPERADMIN",
                    PublicName = "مدير النظام",
                }
            );
            Role.AllRoles.ForEach(role =>
            {
                builder.Entity<Role>().HasData(new
                {
                    Id = role.Name,
                    role.Name,
                    role.NormalizedName,
                    role.PublicName,
                });
            });
            builder.Entity<Department>().HasData(new Department[] {
                new Department(1, "المشروعات", DepartmentType.Projects, new()),
                new Department(2,"المكتب الفني", DepartmentType.TechnicalOffice, new()),
                new Department(3,"المراجعة", DepartmentType.Revision, new()),
                new Department(4,"الحسابات", DepartmentType.Accounting, new()),
                new Department(5,"الكهرباء", DepartmentType.Execution, new()),
                new Department(6, "الاتصالات",  DepartmentType.Execution,new()),
                new Department(7, "الإسكان", DepartmentType.Execution, new()),
                new Department(8, "الخدمات", DepartmentType.Execution, new()),
                new Department(9, "المرافق", DepartmentType.Execution, new()),
                new Department(10, "الزراعة", DepartmentType.Execution, new()),
                new Department(11, "الأمن",  DepartmentType.Execution,new()),
                new Department(12, "التنمية", DepartmentType.Execution,new()),
            });
            /*builder.Entity<User>().HasData(new
            {
                Id = "super-admin",
                UserName = "SuperAdmin",
                NormalizedUserName = "SUPERADMIN",
                FullName = "Super Admin",
                NationalId = "",
                PhoneNumber = "",
                PasswordHash = _passwordHasher.HashPassword(new User(), "$uperAdmin541"),
                ShouldChangePassword = true,
                AccessFailedCount = 0,
                EmailConfirmed = false,
                LockoutEnabled = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString(),
            });*/
            builder.Entity<UserRole>().HasData(new
            {
                UserId = "super-admin",
                RoleId = "superAdmin",
            });
        }
    }
}
