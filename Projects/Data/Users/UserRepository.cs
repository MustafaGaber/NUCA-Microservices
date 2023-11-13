using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Data.Shared;
using NUCA.Projects.Domain.Entities.Users;
using System.Linq.Expressions;

namespace NUCA.Projects.Data.Users
{
    public class UserRepository : Repository<User, long>, IUserRepository
    {
        public UserRepository(ProjectsDatabaseContext database)
         : base(database) { }

        public override Task<List<User>> All()
        {
            return database.Users.Include(u => u.Departments).ToListAsync();
        }

        public override Task<List<User>> Find(Expression<Func<User, bool>> predicate)
        {
            return database.Users
                .Include(u => u.Departments)
                .AsQueryable()
                .Where(predicate)
                .ToListAsync();
        }
        public override Task<User?> Get(long id)
        {
            return database.Users.Include(u => u.Departments).FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
