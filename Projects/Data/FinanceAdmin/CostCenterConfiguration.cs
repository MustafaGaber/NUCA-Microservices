using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Projects.Data.FinanceAdmin
{
    public class CostCenterConfiguration : IEntityTypeConfiguration<CostCenter>
    {
        public void Configure(EntityTypeBuilder<CostCenter> builder)
        {
            builder.HasMany(c => c.Children)
                   .WithOne(c => c.Parent);
        }
    }
}
