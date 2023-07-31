using CustomerBliss.Domain.Entities.Customers;
using CustomerBliss.Domain.Repositories;
using CustomerBliss.Infrastructure.Repositories.DataContext;

namespace CustomerBliss.Infrastructure.Repositories.Customers;

internal class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
{
    public CustomerRepository(CustomerBlissContext dbContext) : base(dbContext)
    {
    }
}
