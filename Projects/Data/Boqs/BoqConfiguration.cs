using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUCA.Projects.Domain.Entities.Boqs;

namespace NUCA.Projects.Data.Boqs
{
    public class BoqConfiguration : IEntityTypeConfiguration<Boq>
    {
        public void Configure(EntityTypeBuilder<Boq> builder)
        {
            //builder.Property("Id").ValueGeneratedNever();
           // builder.HasOne<Project>().WithOne().IsRequired().HasForeignKey<Boq>(b => b.ProjectId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(b => b.Tables).WithOne().IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(b => b.Departments).WithOne().IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class BoqTableConfiguration : IEntityTypeConfiguration<BoqTable>
    {
        public void Configure(EntityTypeBuilder<BoqTable> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasMany(t => t.Sections).WithOne().IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(i => i.WorkType).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(i => i.CostCenter).WithMany().OnDelete(DeleteBehavior.Restrict);
        }
    }

    public class BoqDepartmentConfiguration : IEntityTypeConfiguration<BoqDepartment>
    {
        public void Configure(EntityTypeBuilder<BoqDepartment> builder)
        {
            builder.HasKey(d => new {d.BoqId, d.DepartmentId});
        }
    }

    public class BoqSectionConfiguration : IEntityTypeConfiguration<BoqSection>
    {
        public void Configure(EntityTypeBuilder<BoqSection> builder)
        {
            //builder.HasOne(p => p.Department).WithMany();
            builder.HasMany(s => s.Items).WithOne().IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(i => i.WorkType).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(i => i.CostCenter).WithMany().OnDelete(DeleteBehavior.Restrict);
        }
    }

    public class BoqItemConfiguration : IEntityTypeConfiguration<BoqItem>
    {
        public void Configure(EntityTypeBuilder<BoqItem> builder)
        {
            builder.HasOne(i => i.WorkType).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(i => i.CostCenter).WithMany().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
