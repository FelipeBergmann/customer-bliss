using CustomerBliss.Domain.Entities.Customers;
using CustomerBliss.Domain.Repositories;
using CustomerBliss.Infrastructure.Repositories.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CustomerBliss.Infrastructure.Repositories.Customers;

internal class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
{
    public CustomerRepository(CustomerBlissContext dbContext) : base(dbContext)
    {
    }

    public async Task<(IEnumerable<Customer> DataResult, int TotalCount)> FilterAsync(Expression<Func<Customer, bool>> expression,
        int pageNumber,
        int pageSize,
        bool orderByDesc,
        Expression<Func<Customer, object>>? orderBy)
    {
        var query = SetEntity().Where(expression);
        var countResult = await query.CountAsync();

        if (orderBy is not null)
        {
            if (orderByDesc)
            {
                query = query.OrderByDescending(orderBy);
            }
            else
            {
                query = query.OrderBy(orderBy);
            }
        }

        var queryResult = await query.Skip(pageNumber * pageSize).Take(pageSize).ToListAsync();

        return (queryResult, countResult);
    }
}
