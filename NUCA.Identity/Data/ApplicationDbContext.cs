
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NUCA.Identity.Domain;


namespace NUCA.Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, string, IdentityUserClaim<string>,
    UserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public DbSet<Department> Departments { get; private set; }
        public DbSet<Enrollment> Enrollments { get; private set; }
        public DbSet<DepartmentPermission> DepartmentPermissions { get; private set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Todo: turn off in production
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
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

            builder.Entity<UserRole>(ur =>
            {
                ur.HasKey(ur => new { ur.UserId, ur.RoleId });

                ur.HasOne(ur => ur.Role)
                    .WithMany(r => r.Users)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                ur.HasOne(ur => ur.User)
                    .WithMany(r => r.Roles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });


            builder.Entity<Enrollment>()
                   .HasKey(e => new { e.DepartmentId, e.UserId });

        }
    }
}
