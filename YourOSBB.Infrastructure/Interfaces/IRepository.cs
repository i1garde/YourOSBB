using System.Linq.Expressions;

namespace YourOSBB.Infrastructure.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T> AddAsync(T entity);
    Task DeleteAsync(T entity);
    Task DeleteManyAsync(Expression<Func<T, bool>> filter);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetManyAsync(
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        int? top = null,
        int? skip = null,
        params string[] includeProperties);
}