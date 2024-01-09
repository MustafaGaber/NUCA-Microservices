
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Banks.Data.Banks
{
    public class BankConfiguration : IEntityTypeConfiguration<MainBank>
    {
        public void Configure(EntityTypeBuilder<MainBank> builder)
        {
            builder.HasMany(b => b.Branches).WithOne(b => b.MainBank).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
