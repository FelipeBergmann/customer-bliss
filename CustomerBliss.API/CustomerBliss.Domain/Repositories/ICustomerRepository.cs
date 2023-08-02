using CustomerBliss.Domain.Entities;
using CustomerBliss.Domain.Entities.Customers;
using CustomerBliss.Domain.Repositories.Common;
using System.Linq.Expressions;

namespace CustomerBliss.Domain.Repositories;

public interface ICustomerRepository : IRepository<Customer>
{
    Task<(IEnumerable<Customer> DataResult, int TotalCount)> FilterAsync(Expression<Func<Customer, bool>> expression, 
        int pageNumber, 
        int pageSize, 
        bool orderByDesc,
        Expression<Func<Customer, object>>? orderBy);
}
