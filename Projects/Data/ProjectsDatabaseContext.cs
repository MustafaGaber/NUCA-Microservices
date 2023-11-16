using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Data.Adjustments;
using NUCA.Projects.Data.Boqs;
using NUCA.Projects.Data.Companies;
using NUCA.Projects.Data.Departments;
using NUCA.Projects.Data.Projects;
using NUCA.Projects.Data.Statements;
using NUCA.Projects.Data.Users;
using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.Adjustments;
using NUCA.Projects.Domain.Entities.Boqs;
using NUCA.Projects.Domain.Entities.Companies;
using NUCA.Projects.Domain.Entities.Departments;
using NUCA.Projects.Domain.Entities.FinanceAdmin;
using NUCA.Projects.Domain.Entities.Ledgers;
using NUCA.Projects.Domain.Entities.Projects;
using NUCA.Projects.Domain.Entities.Shared;
using NUCA.Projects.Domain.Entities.Statements;
using NUCA.Projects.Domain.Entities.Users;
using System.Security.AccessControl;

namespace NUCA.Projects.Data
{
    public class ProjectsDatabaseContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Boq> Boqs { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Statement> Statements { get; set; }
        public DbSet<Adjustment> Adjustments { get; set; }
        public DbSet<WorkType> WorkTypes { get; set; }
        public DbSet<AwardType> AwardTypes { get; set; }
        public DbSet<Ledger> Ledgers { get; set; }

        public ProjectsDatabaseContext(DbContextOptions<ProjectsDatabaseContext> options) : base(options){}

        public new DbSet<T> Set<T, TId>() where T : Entity<TId>
        {
            return base.Set<T>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new BoqConfiguration());
            modelBuilder.ApplyConfiguration(new TableConfiguration());
            modelBuilder.ApplyConfiguration(new SectionConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new StatementConfiguration());
            modelBuilder.ApplyConfiguration(new StatementTableConfiguration());
            modelBuilder.ApplyConfiguration(new StatementSectionConfiguration());
            modelBuilder.ApplyConfiguration(new StatementItemConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new AdjustmentConfiguration());

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                //  if (entityType.DisplayName() != nameof(Date) && entityType.DisplayName() != nameof(Duration))
                if (!entityType.IsOwned())
                {
                    modelBuilder.Entity(entityType.Name).Property<DateTime>("Created");
                    modelBuilder.Entity(entityType.Name).Property<DateTime>("LastModified");
                }
            }
        }

        public override int SaveChanges()
        {
            OnSaveChanges();
            return base.SaveChanges();
        }

        /*public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnSaveChanges();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }*/

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnSaveChanges();
            return base.SaveChangesAsync(cancellationToken);
        }

        /*public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnSaveChanges();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }*/

        private void OnSaveChanges()
        {
            ChangeTracker.DetectChanges();
            var now = DateTime.Now;
            foreach (var entry in ChangeTracker.Entries().Where(e =>
            (e.State == EntityState.Added || e.State == EntityState.Modified) &&
            !e.Metadata.IsOwned()))
            {
                entry.Property("LastModified").CurrentValue = now;
                if (entry.State == EntityState.Added)
                {
                    entry.Property("Created").CurrentValue = now;
                }
            }

            List<AggregateRoot<long>> aggregateRoots = ChangeTracker
                   .Entries()
                   .Where(x => x.Entity is AggregateRoot<long>)
                   .Select(x => (AggregateRoot<long>)x.Entity)
                   .ToList();
            foreach (AggregateRoot<long> aggregateRoot in aggregateRoots)
            {
                foreach (IDomainEvent domainEvent in aggregateRoot.DomainEvents)
                {
                    DomainEvents.Dispatch(domainEvent);
                }
                aggregateRoot.ClearEvents();
            }

            List<AggregateRoot<int>> aggregateRoots2 = ChangeTracker
                  .Entries()
                  .Where(x => x.Entity is AggregateRoot<int>)
                  .Select(x => (AggregateRoot<int>)x.Entity)
                  .ToList();
            foreach (AggregateRoot<int> aggregateRoot in aggregateRoots2)
            {
                foreach (IDomainEvent domainEvent in aggregateRoot.DomainEvents)
                {
                    DomainEvents.Dispatch(domainEvent);
                }
                aggregateRoot.ClearEvents();
            }
        }


        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DbCoreConnectionString");
                optionsBuilder.UseSqlServer(connectionString);
           }
        }*/
    }
}
