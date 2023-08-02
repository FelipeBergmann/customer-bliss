using CustomerBliss.Domain.UseCases.Customers;
using CustomerBliss.Domain.UseCases.Surveys;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerBliss.Domain.UseCases.Extensions;

public static class UseCaseExtensions
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddTransient<ICreateCustomerUseCase, CreateCustomerUseCase>();
        services.AddTransient<IFilterCustomerQueryUseCase, FilterCustomerQueryUseCase>();
        services.AddTransient<IGetCountCustomerUseCase, GetCountCustomerUseCase>();

        services.AddTransient<ICreateSurveyUseCase, CreateSurveyUseCase>();
        services.AddTransient<IFindSurveyUseCase, FindSurveyUseCase>();
        services.AddTransient<IListSurveyUseCase, ListSurveyUseCase>();
        services.AddTransient<IAddSurveyCustomerUseCase, AddSurveyCustomerUseCase>();
        services.AddTransient<IAddSurveyReviewUseCase, AddSurveyReviewUseCase>();

        return services;
    } 
}
