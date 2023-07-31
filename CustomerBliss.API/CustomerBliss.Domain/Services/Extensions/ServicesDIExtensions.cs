using CustomerBliss.Domain.Services.Customers;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerBliss.Domain.Services.Extensions;

public static class ServicesDIExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<ICustomerCategoryManager, CustomerCategoryManager>();

        return services;
    }
}
