using CustomerBliss.Domain.Entities.Customers;

namespace CustomerBliss.Domain.Services.Customers;

public interface ICustomerCategoryManager
{
    CustomerCategory ProcessCategory(double? lastScore);
}
public class CustomerCategoryManager : ICustomerCategoryManager
{
    public CustomerCategory ProcessCategory(double? lastScore) =>
    lastScore switch
    {
        null => CustomerCategory.None,
        <= 6 => CustomerCategory.Detrator,
        <= 8 => CustomerCategory.Neutral,
        _ => CustomerCategory.Promoter,
    };
}
