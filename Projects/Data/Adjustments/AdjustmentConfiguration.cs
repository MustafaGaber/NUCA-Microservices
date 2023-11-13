using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUCA.Projects.Domain.Entities.Adjustments;
using NUCA.Projects.Domain.Entities.Projects;
using NUCA.Projects.Domain.Entities.Statements;

namespace NUCA.Projects.Data.Adjustments
{
    public class AdjustmentConfiguration : IEntityTypeConfiguration<Adjustment>
    {
        public void Configure(EntityTypeBuilder<Adjustment> builder)
        {
            builder.HasOne<Project>()
                .WithMany()
                .HasForeignKey(i => i.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property("Id").ValueGeneratedNever();
            builder.HasOne<Statement>().WithOne().HasForeignKey<Adjustment>(a => a.Id).OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(i => i.Withholdings)
             .WithOne()
             .OnDelete(DeleteBehavior.Cascade);

        }
    }

}
