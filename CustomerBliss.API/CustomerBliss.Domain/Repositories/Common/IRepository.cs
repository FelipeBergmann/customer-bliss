using System.Linq.Expressions;

namespace CustomerBliss.Domain.Repositories.Common;

public interface IRepository<TEntity> 
{
    Task<TEntity?> GetByIdAsync(Guid id);
    Task<(IEnumerable<TEntity> DataResult, int TotalCount)> FilterAsync(Expression<Func<TEntity, bool>> expression, int pageNumber = 1, int pageSize = 50);
    Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> expression);
    Task<(IEnumerable<TEntity> DataResult, int TotalCount)> GetAllAsync(int pageNumber = 1, int pageSize = 50);
    Task<int> CountAsync();
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);
    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    void UpdateRange(TEntity[] entity);
    void Remove(TEntity entity);
    Task<int> SaveChangesAsync();
}
