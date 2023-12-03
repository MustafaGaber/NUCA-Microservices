﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUCA.Projects.Domain.Entities.Projects;
using NUCA.Projects.Domain.Entities.Statements;
using System.Reflection.Metadata;

namespace NUCA.Projects.Data.Statements
{
    public class StatementConfiguration : IEntityTypeConfiguration<Statement>
    {
        public void Configure(EntityTypeBuilder<Statement> builder)
        {
            builder
                .Ignore(s => s.WorksTables)
                .Ignore(s => s.SuppliesTables);
            builder.HasMany(s => s.Tables)
                .WithOne()
                .HasForeignKey(t => t.StatementId)
                .OnDelete(DeleteBehavior.Cascade);

             builder.HasMany(s => s.ExternalSuppliesItems)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.Withholdings)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
    public class StatementTableConfiguration : IEntityTypeConfiguration<StatementTable>
    {
        public void Configure(EntityTypeBuilder<StatementTable> builder)
        {
           /* builder.HasDiscriminator(t => t.Type)
                .HasValue<WorksTable>(StatementTableType.Works)
                .HasValue<SuppliesTable>(StatementTableType.Supplies);*/

            builder.HasMany(t => t.Sections)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            /* builder.HasMany(t => t.ExternalSuppliesItems)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);*/
        }
    }
    /*public class WorksTableConfiguration : IEntityTypeConfiguration<WorksTable>
    {
        public void Configure(EntityTypeBuilder<WorksTable> builder)
        {
            builder.HasBaseType(typeof(StatementTable));

            builder.HasMany(t => t.Sections)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
    public class SuppliesTableConfiguration : IEntityTypeConfiguration<SuppliesTable>
    {
        public void Configure(EntityTypeBuilder<SuppliesTable> builder)
        {
            builder.HasBaseType(typeof(StatementTable));

            builder.HasMany(t => t.Sections)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(t => t.ExternalSuppliesItems)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }*/

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
