using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NUCA.Identity.Models;

namespace NUCA.Identity.Data
{
    public class IdentityDbContext : IdentityDbContext<User>
    {
        public DbSet<Department> Departments { get; private set; }
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
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
