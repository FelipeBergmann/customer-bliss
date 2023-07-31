using CustomerBliss.BuildingBlocks.UseCase;
using CustomerBliss.Domain.Repositories;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace CustomerBliss.Domain.UseCases.Customers;


public record FilterCustomerQuery(string Name);

public record FilterCustomerQueryResponse(ICollection<CustomerData> Customers, int TotalCustomerRegistered);

public record CustomerData(Guid Id,
                        string Name,
                        string ContactName,
                        string CompanyDocument,
                        double? LastReviewScore,
                        DateOnly InitialDate);
public interface IFilterCustomerQueryUseCase : IUseCase<FilterCustomerQuery, FilterCustomerQueryResponse> { }

public class FilterCustomerQueryUseCase : UseCaseBase<FilterCustomerQuery, FilterCustomerQueryResponse>, IFilterCustomerQueryUseCase
{
    private readonly ICustomerRepository _customerRepository;

    public FilterCustomerQueryUseCase(ILogger<FilterCustomerQueryUseCase> logger,
                                    ICustomerRepository customerRepository)
        : base(logger, null)
    {
        _customerRepository = customerRepository;
    }

    protected override async Task<FilterCustomerQueryResponse> Execute(FilterCustomerQuery command)
    {        
        var query = await _customerRepository.FilterAsync(c => c.CompanyName.ToLower().Contains(command.Name.ToLower()));

        if (query is null)
        {
            Fault(UseCaseErrorType.BadRequest, "Not found");
        }

        int totalCustomers = await _customerRepository.CountAsync();

        var customers = query is null ? new List<CustomerData>() 
            : query.Select(c => new CustomerData(
                c.Id,
                c.CompanyName,
                c.ContactName,
                c.CompanyDocument,
                c.LastReviewScore,
                c.InitialDate)).ToList();


        var response = new FilterCustomerQueryResponse(customers, totalCustomers);

        return response;
    }
}