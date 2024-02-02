
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NUCA.Identity.Domain;


namespace NUCA.Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, string, IdentityUserClaim<string>,
    UserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
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

            builder.Entity<UserGroup>().HasKey(g => g.Id);

            builder.Entity<Department>().HasKey(d => d.DepartmentId);

            builder.Entity<Department>()
                   .HasMany(d => d.Permissions)
                   .WithMany();

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
            builder.Entity<Role>().HasData(new Role("superAdmin", "مدير النظام"));
            Role.AllRoles.ForEach(role =>
            {
                builder.Entity<Role>().HasData(role);
            });
        }
    }
}
