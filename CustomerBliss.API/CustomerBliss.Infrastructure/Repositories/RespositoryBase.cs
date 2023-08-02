using CustomerBliss.Domain.Entities;
using CustomerBliss.Domain.Repositories.Common;
using CustomerBliss.Infrastructure.Repositories.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CustomerBliss.Infrastructure.Repositories;

public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
{
    protected readonly CustomerBlissContext _dbContext;

    protected DbSet<TEntity> SetEntity() => _dbContext.Set<TEntity>();

    protected RepositoryBase(CustomerBlissContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TEntity?> GetByIdAsync(Guid id) => await SetEntity().SingleOrDefaultAsync(x => x.Id == id);

    public async Task<(IEnumerable<TEntity>, int)> FilterAsync(Expression<Func<TEntity, bool>> expression, int pageNumber = 1, int pageSize = 50)
    {
        var query = SetEntity().Where(expression);
        var countResult = await query.CountAsync();
        var queryResult = await query.Skip(pageNumber * pageSize).Take(pageSize).ToListAsync();

        return (queryResult, countResult);
    }

    public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> expression) => await SetEntity().FirstOrDefaultAsync(expression);

    public async Task<(IEnumerable<TEntity>, int)> GetAllAsync(int pageNumber = 0, int pageSize = 50)
    {
        var query = SetEntity();
        var countResult = await query.CountAsync();
        var queryResult = await query.Skip(pageNumber * pageSize).Take(pageSize).ToListAsync();

        return (queryResult, countResult);
    }

    public async Task<int> CountAsync() => await SetEntity().CountAsync();
    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression) => await SetEntity().AnyAsync(expression);

    public async Task AddAsync(TEntity entity) => await SetEntity().AddAsync(entity);
    public void Update(TEntity entity) => SetEntity().Update(entity);
    public void UpdateRange(TEntity[] entity) => SetEntity().UpdateRange(entity);

    public void AddRange(IEnumerable<TEntity> entities) => SetEntity().AddRange(entities);

    public void Remove(TEntity entity) => SetEntity().Remove(entity);

    public void RemoveRange(IEnumerable<TEntity> entities) => SetEntity().RemoveRange(entities);

    public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();
}
