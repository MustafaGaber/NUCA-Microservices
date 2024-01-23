using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUCA.Projects.Domain.Entities.Boqs;
using NUCA.Projects.Domain.Entities.Projects;

namespace NUCA.Projects.Data.Projects
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasOne(p => p.Boq).WithOne(b => b.Project).HasForeignKey<Boq>(b => b.ProjectId).IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Company).WithMany().OnDelete(DeleteBehavior.Restrict);
            //builder.HasOne(p => p.Department).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.WorkType).WithMany().OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.ModifiedEndDates).WithOne()
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Privileges).WithOne()
                   .IsRequired()
                   .HasForeignKey(p => p.ProjectId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Classifications).WithMany(c => c.Projects);

            builder.HasMany(p => p.Statements).WithOne()
                   .HasForeignKey(s => s.ProjectId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.AdvancePaymentDeductions).WithOne()
                 .HasForeignKey(d => d.ProjectId)
                 .OnDelete(DeleteBehavior.Restrict);

            /*  builder.OwnsMany(
               p => p.ModifiedEndDates, a =>
               {
                   a.ToTable("EndDates");
                   a.WithOwner().HasForeignKey("ProjectId");
                   a.HasKey("Id");
                   a.Property("Id");
              });*/
            builder.OwnsOne(p => p.Duration);
        }
    }
}
