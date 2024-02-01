using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUCA.Projects.Domain.Entities.Companies;

namespace NUCA.Projects.Data.Companies
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.TaxAuthority).WithMany(t => t.Companies);
        }
    }
}
