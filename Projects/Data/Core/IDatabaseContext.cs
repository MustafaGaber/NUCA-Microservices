using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Domain.Entities.Projects;
using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.Boqs;
using NUCA.Projects.Domain.Entities.Companies;
using NUCA.Projects.Domain.Entities.Users;
using NUCA.Projects.Domain.Entities.Statements;
using NUCA.Projects.Domain.Entities.Departments;

namespace NUCA.Projects.Data.Core
{
    public interface IDatabaseContext
    {
        DbSet<Project> Projects { get; set; }
        DbSet<Boq> Boqs { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<Company> Companies { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Statement> Statements { get; set; }
        DbSet<T> Set<T, TId>() where T : Entity<TId>;
        void Save();
    }
}
