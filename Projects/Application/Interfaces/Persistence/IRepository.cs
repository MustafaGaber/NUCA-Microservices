using NUCA.Projects.Domain.Common;
using System.Linq.Expressions;

namespace NUCA.Projects.Application.Interfaces.Persistence
{
    public interface IRepository<T> where T : Entity
    {

        Task<List<T>> All();
        Task<List<TargetT>> Select<TargetT>(Expression<Func<T, TargetT>> selector);
        Task<TargetT?> SelectOne<TargetT>(Expression<Func<T, bool>> predicate, Expression<Func<T, TargetT>> selector);
        Task<List<T>> GetSome(List<long> ids);
        Task<List<T>> Find(Expression<Func<T, bool>> predicate);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T?> Get(long id);
        Task Delete(long id);
        Task SaveChangesAsync();


        //  public Task<T> GetByIdAsync<T, TId>(TId id) where T : BaseEntity, IAggregateRoot
        //  {
        //    return _dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id.Equals(id));
        //  }

        //  public Task<T> GetAsync<T, TId>(ISpecification<T> spec) where T : BaseEntity, IAggregateRoot
        //  {
        //    var specificationResult = ApplySpecification<T, TId>(spec);
        //    return specificationResult.FirstOrDefaultAsync();
        //  }

        //  public Task<List<T>> ListAsync<T, TId>() where T : BaseEntity, IAggregateRoot
        //  {
        //    return _dbContext.Set<T>().ToListAsync();
        //  }

        //  public Task<List<T>> ListAsync<T, TId>(ISpecification<T> spec) where T : BaseEntity, IAggregateRoot
        //  {
        //    var specificationResult = ApplySpecification<T, TId>(spec);
        //    return specificationResult.ToListAsync();
        //  }

        //  public async Task<T> AddAsync<T, TId>(T entity) where T : BaseEntity, IAggregateRoot
        //  {
        //    await _dbContext.Set<T>().AddAsync(entity);
        //    await _dbContext.SaveChangesAsync();

        //    return entity;
        //  }

        //  public Task UpdateAsync<T, TId>(T entity) where T : BaseEntity, IAggregateRoot
        //  {
        //    _dbContext.Set<T>().Update(entity);
        //    return _dbContext.SaveChangesAsync();
        //  }

        //  public Task DeleteAsync<T, TId>(T entity) where T : BaseEntity, IAggregateRoot
        //  {
        //    _dbContext.Set<T>().Remove(entity);
        //    return _dbContext.SaveChangesAsync();
        //  }

        //  public Task CountAsync<T, TId>(ISpecification<T> spec) where T : BaseEntity, IAggregateRoot
        //  {
        //    var specificationResult = ApplySpecification<T, TId>(spec);
        //    return specificationResult.CountAsync();
        //  }

        //  private IQueryable<T> ApplySpecification<T, TId>(ISpecification<T> spec) where T : BaseEntity
        //  {
        //    var evaluator = new SpecificationEvaluator<T>();
        //    return evaluator.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        //  }
        //}

    }
}
