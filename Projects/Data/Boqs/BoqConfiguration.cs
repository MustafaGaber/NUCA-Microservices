using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUCA.Projects.Domain.Entities.Boqs;
using NUCA.Projects.Domain.Entities.Projects;

namespace NUCA.Projects.Data.Boqs
{
    public class BoqConfiguration : IEntityTypeConfiguration<Boq>
    {
        public void Configure(EntityTypeBuilder<Boq> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property("Id").ValueGeneratedNever();
            builder.HasOne<Project>().WithOne().IsRequired().HasForeignKey<Boq>(b => b.Id).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(b => b.Tables).WithOne().IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class TableConfiguration : IEntityTypeConfiguration<BoqTable>
    {
        public void Configure(EntityTypeBuilder<BoqTable> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasMany(t => t.Sections).WithOne().IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class SectionConfiguration : IEntityTypeConfiguration<BoqSection>
    {
        public void Configure(EntityTypeBuilder<BoqSection> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasOne(p => p.Department).WithMany();
            builder.HasMany(s => s.Items).WithOne().IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
