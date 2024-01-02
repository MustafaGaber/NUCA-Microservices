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
        DbSet<Project> Projects { get; init; }
        DbSet<Boq> Boqs { get; init; }
        DbSet<Department> Departments { get; init; }
        DbSet<Company> Companies { get; init; }
        DbSet<User> Users { get; init; }
        DbSet<Statement> Statements { get; init; }
        DbSet<T> Set<T, TId>() where T : Entity;
        void Save();
    }
}
