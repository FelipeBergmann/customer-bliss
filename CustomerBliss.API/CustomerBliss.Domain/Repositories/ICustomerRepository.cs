using CustomerBliss.Domain.Entities.Customers;
using CustomerBliss.Domain.Repositories.Common;

namespace CustomerBliss.Domain.Repositories;

public interface ICustomerRepository : IRepository<Customer>
{
}
