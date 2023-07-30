using CustomerBliss.BuildingBlocks.UseCase;
using CustomerBliss.Domain.Repositories;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace CustomerBliss.Domain.UseCases.Customers;


public record FilterCustomerQuery(string Name);

public record FilterCustomerQueryResponse(Guid Id,
                                        string Name,
                                        string ContactName,
                                        string CompanyDocument,
                                        DateOnly InitialDate);

public interface IFilterCustomerQueryUseCase : IUseCase<FilterCustomerQuery, IEnumerable<FilterCustomerQueryResponse>> { }

public class FilterCustomerQueryUseCase : UseCaseBase<FilterCustomerQuery, IEnumerable<FilterCustomerQueryResponse>>, IFilterCustomerQueryUseCase
{
    private readonly ICustomerRepository _customerRepository;

    public FilterCustomerQueryUseCase(ILogger logger,
                                    AbstractValidator<FilterCustomerQuery>? validator,
                                    ICustomerRepository customerRepository)
        : base(logger, validator)
    {
        _customerRepository = customerRepository;
    }

    protected override async Task<IEnumerable<FilterCustomerQueryResponse>> Execute(FilterCustomerQuery command)
    {
        var query = await _customerRepository.FilterAsync(c => c.CompanyName.Contains(command.Name, StringComparison.InvariantCultureIgnoreCase));

        if (query is null)
        {
            Fault(UseCaseErrorType.Unknown, "Not found");
        }

        return query!.Select(c => new FilterCustomerQueryResponse(c.Id,
                                                                 c.CompanyName,
                                                                 c.ContactName,
                                                                 c.CompanyDocument,
                                                                 c.InitialDate));
    }
}