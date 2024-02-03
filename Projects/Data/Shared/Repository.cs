using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Common;
using System.Linq.Expressions;

namespace NUCA.Projects.Data.Shared
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly ProjectsDatabaseContext database;

        public virtual IQueryable<T> Query
        {
            get
            {
                return database.Set<T>();
            }
        }
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
            return Query.Where(predicate).ToListAsync();
        }

        public virtual async Task<T?> Get(long id)
        {
            var item = await Query.FirstOrDefaultAsync(i => i.Id == id);
            return item;
        }

        public virtual Task<List<T>> All()
        {
            return Query.ToListAsync();
        }

        public virtual async Task<T> Update(T entity)
        {
            T item = database.Set<T>().Update(entity).Entity;
            await database.SaveChangesAsync();
            return item;
        }

        public virtual async Task Delete(long id)
        {
            var entity = await Query.FirstOrDefaultAsync(i => i.Id == id);
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
            return Query.Select(selector).ToListAsync();
        }

        public virtual Task<List<T>> GetSome(List<long> ids)
        {
            return Query.Where((item) => ids.Contains(item.Id)).ToListAsync();
        }

        public Task<TargetT?> SelectOne<TargetT>(Expression<Func<T, bool>> predicate, Expression<Func<T, TargetT>> selector)
        {
            return Query.Where(predicate).Select(selector).FirstOrDefaultAsync();
        }
    }
}
