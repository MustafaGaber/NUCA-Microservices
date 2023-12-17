using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using NUCA.Identity.Domain;
using System.Reflection.Emit;

namespace NUCA.Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Department> Departments { get; private set; }
        public DbSet<Enrollment> Enrollments { get; private set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Department>()
                   .HasMany(d => d.Roles)
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

            builder.Entity<Enrollment>()
                   .HasKey(e => new { e.DepartmentId, e.UserId });

        }
    }
}
