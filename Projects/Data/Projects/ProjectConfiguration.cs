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
            builder.HasOne(p => p.Company).WithMany(c => c.Projects).OnDelete(DeleteBehavior.Restrict);
            //builder.HasOne(p => p.Department).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.WorkType).WithMany().OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.ModifiedEndDates).WithOne()
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.AssigneeMainBank).WithMany();
            builder.HasOne(p => p.AssigneeBankBranch).WithMany();

            builder.HasOne(p => p.FromLedger).WithMany();
            builder.HasOne(p => p.ToLedger).WithMany();

            builder.HasMany(p => p.Privileges)
                   .WithOne()
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

            builder.OwnsOne(p => p.Duration);
        }
    }
}
