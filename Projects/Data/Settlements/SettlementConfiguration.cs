using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUCA.Projects.Domain.Entities.Settlements;

namespace NUCA.Projects.Data.Settlements
{
    public class SettlementConfiguration : IEntityTypeConfiguration<Settlement>
    {
        public void Configure(EntityTypeBuilder<Settlement> builder)
        {
            builder.HasOne(a => a.Project)
                .WithMany()
                .HasForeignKey(a => a.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property("Id").ValueGeneratedNever();
            builder.HasOne(a => a.Statement).WithOne().HasForeignKey<Settlement>(a => a.Id).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(a => a.Withholdings)
                   .WithOne()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.AdvancePaymentDeduction)
                   .WithOne().IsRequired(false)
                   .HasForeignKey<AdvancePaymentDeduction>(a => a.SettlementId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }

}
