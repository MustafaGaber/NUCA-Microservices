using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUCA.Projects.Domain.Entities.Projects;
using NUCA.Projects.Domain.Entities.Statements;

namespace NUCA.Projects.Data.Statements
{
    public class StatementConfiguration : IEntityTypeConfiguration<Statement>
    {
        public void Configure(EntityTypeBuilder<Statement> builder)
        {
            /*builder.HasOne<Project>()
                .WithMany()
                .HasForeignKey(i => i.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);*/
            builder.HasMany(i => i.Tables)
                .WithOne()
                .HasForeignKey(t => t.StatementId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(i => i.Withholdings)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            builder.Ignore(s => s.WorksTables)
                   .Ignore(s => s.SuppliesTables)
                   .Ignore(s => s.ExternalSuppliesTables);
            /*builder.HasMany(i => i.WorksTables)
                .WithOne()
                .HasForeignKey(t => t.StatementId)
                .OnDelete(DeleteBehavior.Cascade);*/
        }
    }
    public class StatementTableConfiguration : IEntityTypeConfiguration<StatementTable>
    {
        public void Configure(EntityTypeBuilder<StatementTable> builder)
        {

            /*builder.UseTphMappingStrategy();
            builder
                .HasDiscriminator<int>("Type")
                .HasValue<WorksTable>(1)
                .HasValue<SuppliesTable>(2);*/

            builder.HasMany(t => t.Sections)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            

            /* builder.HasDiscriminator<int>("Type")
                 .HasValue<StatementTable>((int)StatementTableType.Works)
                 .HasValue<StatementTable>((int)StatementTableType.Supplies);*/
            // builder.HasOne<Statement>().WithMany().HasForeignKey("StatementId");
            // builder.HasOne<Statement>().WithMany().HasForeignKey("StatementId");
        }
    }

    public class StatementSectionConfiguration : IEntityTypeConfiguration<StatementSection>
    {
        public void Configure(EntityTypeBuilder<StatementSection> builder)
        {
            builder.HasMany(s => s.Items).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class StatementItemConfiguration : IEntityTypeConfiguration<StatementItem>
    {
        public void Configure(EntityTypeBuilder<StatementItem> builder)
        {
            //builder.HasMany(s => s.Percentages).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
