using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Common;
using System.Linq.Expressions;

namespace NUCA.Projects.Data.Shared
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly ProjectsDatabaseContext database;

        public Repository(ProjectsDatabaseContext database)
        {
            this.database = database;
        }

        public virtual async Task<T> Add(T entity)
        {
            T item = database.Set<T>().Add(entity).Entity;
            await database.SaveChangesAsync();
            return item;
        }

        public virtual Task<List<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return database.Set<T>().AsQueryable().Where(predicate).ToListAsync();
        }

        public virtual async Task<T?> Get(long id)
        {
            var item = await database.Set<T>().FindAsync(id);
            return item;
        }

        public virtual Task<List<T>> All()
        {
            return database.Set<T>().ToListAsync();
        }

        public virtual async Task<T> Update(T entity)
        {
            T item = database.Set<T>().Update(entity).Entity;
            await database.SaveChangesAsync();
            return item;
        }

        public virtual async Task Delete(long id)
        {
            var entity = await database.Set<T>().FindAsync(id);
            if (entity == null) return;
            database.Set<T>().Remove(entity);
            await database.SaveChangesAsync();
        }

        public virtual Task SaveChangesAsync()
        {
            return database.SaveChangesAsync();
        }

        public virtual Task<List<TargetT>> Select<TargetT>(Expression<Func<T, TargetT>> selector)
        {
            return database.Set<T>().Select(selector).ToListAsync();
        }

        public virtual Task<List<T>> GetSome(List<long> ids)
        {
            return database.Set<T>().Where((item) => ids.Contains(item.Id)).ToListAsync();
        }

        public Task<TargetT?> SelectOne<TargetT>(Expression<Func<T, bool>> predicate, Expression<Func<T, TargetT>> selector)
        {
            return database.Set<T>().Where(predicate).Select(selector).FirstOrDefaultAsync();
        }
    }
}
