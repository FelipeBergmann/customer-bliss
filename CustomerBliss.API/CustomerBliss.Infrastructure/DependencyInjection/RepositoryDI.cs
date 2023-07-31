using CustomerBliss.Domain.Repositories;
using CustomerBliss.Infrastructure.Repositories.Customers;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerBliss.Infrastructure.DependencyInjection;

public static class RepositoryDI
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<ICustomerRepository, CustomerRepository>();
        services.AddTransient<ISurveyRepository, SurveyRepository>();

        return services;
    }
}
