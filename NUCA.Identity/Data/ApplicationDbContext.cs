using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NUCA.Identity.Domain;

namespace NUCA.Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Department> Departments { get; private set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Department>()
                   .HasOne(d => d.Role)
                   .WithMany()
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
