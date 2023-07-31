using System.Linq.Expressions;

namespace CustomerBliss.Domain.Repositories.Common;

public interface IRepository<TEntity> 
{
    Task<TEntity?> GetByIdAsync(Guid id);
    Task<IEnumerable<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> expression);
    Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> expression);
    Task<int> CountAsync();
    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    Task<int> SaveChangesAsync();
}
