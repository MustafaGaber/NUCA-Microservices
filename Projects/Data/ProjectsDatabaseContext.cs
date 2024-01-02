using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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
using System.Security.Claims;

namespace NUCA.Projects.Data
{
    public class ProjectsDatabaseContext : DbContext
    {
        public DbSet<Project> Projects { get; init; }
        public DbSet<Boq> Boqs { get; init; }
        public DbSet<Department> Departments { get; init; }
        public DbSet<Company> Companies { get; init; }
        public DbSet<User> Users { get; init; }
        public DbSet<Statement> Statements { get; init; }
        public DbSet<Adjustment> Adjustments { get; init; }
        public DbSet<WorkType> WorkTypes { get; init; }
        public DbSet<AwardType> AwardTypes { get; init; }
        public DbSet<Ledger> Ledgers { get; init; }

        private IHttpContextAccessor _contextAccessor;
        public ProjectsDatabaseContext(DbContextOptions<ProjectsDatabaseContext> options, IHttpContextAccessor contextAccessor) : base(options)
        {
            _contextAccessor = contextAccessor;
        }

        public new DbSet<T> Set<T>() where T : Entity
        {
            return base.Set<T>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<WorksTable>();
            modelBuilder.Ignore<SuppliesTable>();
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new BoqConfiguration());
            modelBuilder.ApplyConfiguration(new TableConfiguration());
            modelBuilder.ApplyConfiguration(new SectionConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new StatementTableConfiguration());
            modelBuilder.ApplyConfiguration(new StatementConfiguration());
            modelBuilder.ApplyConfiguration(new StatementSectionConfiguration());
            modelBuilder.ApplyConfiguration(new StatementItemConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new AdjustmentConfiguration());

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (!entityType.IsOwned())
                {
                    modelBuilder.Entity(entityType.Name).Property<DateTime>("Created");
                    modelBuilder.Entity(entityType.Name).Property<DateTime>("LastModified");
                   // modelBuilder.Entity(entityType.Name).Property<string>("CreatedBy");
                   // modelBuilder.Entity(entityType.Name).Property<string>("UpdatedBy");
                }
            }
        }

        public override int SaveChanges()
        {
            OnSaveChanges();
            return base.SaveChanges();
        }

    

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnSaveChanges();
            return base.SaveChangesAsync(cancellationToken);
        }

        /*public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnSaveChanges();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }*/

        /*public override Task SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnSaveChanges();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }*/

        private void OnSaveChanges()
        {
            ChangeTracker.DetectChanges();
            var now = DateTime.Now;
            var httpContextAccessor = this.GetService<IHttpContextAccessor>();
            string? userId = _contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            foreach (var entry in ChangeTracker.Entries().Where(e =>
            (e.State == EntityState.Added || e.State == EntityState.Modified) &&
            !e.Metadata.IsOwned()))
            {
                entry.Property("LastModified").CurrentValue = now;
                if (userId != null && (entry.Entity is Entity))
                {
                    entry.Property("UpdatedBy").CurrentValue = userId;
                }
                if (entry.State == EntityState.Added)
                {
                    entry.Property("Created").CurrentValue = now;
                    if (userId != null)
                    {
                        entry.Property("CreatedBy").CurrentValue = userId;
                    }
                }
            }

            List<AggregateRoot> aggregateRoots = ChangeTracker
                   .Entries()
                   .Where(x => x.Entity is AggregateRoot)
                   .Select(x => (AggregateRoot)x.Entity)
                   .ToList();
            foreach (AggregateRoot aggregateRoot in aggregateRoots)
            {
                foreach (IDomainEvent domainEvent in aggregateRoot.DomainEvents)
                {
                    DomainEvents.Dispatch(domainEvent);
                }
                aggregateRoot.ClearEvents();
            }

           /*/ List<AggregateRoot> aggregateRoots2 = ChangeTracker
                  .Entries()
                  .Where(x => x.Entity is AggregateRoot)
                  .Select(x => (AggregateRoot)x.Entity)
                  .ToList();
            foreach (AggregateRoot aggregateRoot in aggregateRoots2)
            {
                foreach (IDomainEvent domainEvent in aggregateRoot.DomainEvents)
                {
                    DomainEvents.Dispatch(domainEvent);
                }
                aggregateRoot.ClearEvents();
            }*/
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
