using CustomerBliss.Domain.UseCases.Customers;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerBliss.Domain.UseCases.Extensions;

public static class UseCaseExtensions
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddTransient<ICreateCustomerUseCase, CreateCustomerUseCase>();
        services.AddTransient<IFilterCustomerQueryUseCase, FilterCustomerQueryUseCase>();

        return services;
    } 
}
