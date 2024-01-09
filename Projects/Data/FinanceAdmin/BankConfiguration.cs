using NUCA.Banks.Domain.Entities.Banks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUCA.Banks.Domain.Entities.Boqs;

namespace NUCA.Banks.Data.Banks
{
    public class BankConfiguration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.HasOne(p => p.Boq).WithOne(b => b.Bank).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
