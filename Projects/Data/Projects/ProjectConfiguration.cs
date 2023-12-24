﻿using NUCA.Projects.Domain.Entities.Projects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUCA.Projects.Domain.Entities.Boqs;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace NUCA.Projects.Data.Projects
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasOne(p => p.Boq).WithOne(b => b.Project).HasForeignKey<Boq>(b => b.ProjectId).IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Company).WithMany().OnDelete(DeleteBehavior.Restrict);
            //builder.HasOne(p => p.Department).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Type).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.Privileges).WithOne()
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(p => p.Statements).WithOne()
                   .HasForeignKey(s => s.ProjectId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.OwnsMany(
                p => p.ModifiedEndDates, a =>
                {
                    a.ToTable("EndDates");
                    a.WithOwner().HasForeignKey("ProjectId");
                    a.HasKey("Id");
                    a.Property<long>("Id");
                });
            builder.OwnsOne(p => p.Duration);
        }
    }
}
