using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUCA.Projects.Domain.Entities.Departments;

namespace NUCA.Projects.Data.Departments
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasMany(d => d.Users).WithMany(u => u.Departments);

            /*builder.HasMany(d => d.Groups).WithOne(g => g.Department)
                .OnDelete(DeleteBehavior.Cascade);*/
        }
    }
    /* public class GroupConfiguration : IEntityTypeConfiguration<Group>
     {
         public void Configure(EntityTypeBuilder<Group> builder)
         {
             builder.ToTable("DGroup");
             builder.HasMany(g => g.ExecutionDepartments).WithOne(d => d.Group)
                 .OnDelete(DeleteBehavior.Cascade);
         }
     }

     public class DepartmentGroupConfiguration : IEntityTypeConfiguration<DepartmentGroup>
     {
         public void Configure(EntityTypeBuilder<DepartmentGroup> builder)
         {
             builder.HasKey(d => new {  d.DepartmentId, d.GroupId });
         }
     }*/
}
