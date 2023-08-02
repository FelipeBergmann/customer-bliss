using CustomerBliss.BuildingBlocks.Pagination;
using CustomerBliss.BuildingBlocks.UseCase;
using CustomerBliss.Domain.Repositories;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace CustomerBliss.Domain.UseCases.Customers;


public record FilterCustomerQuery(string? Name = default, bool? OrderByLastReviewDate = default, bool? OrderByDesc = default);

public record FilterCustomerQueryResponse(ICollection<CustomerData> Customers);

public record CustomerData(Guid Id,
                        string Name,
                        string ContactName,
                        string CompanyDocument,
                        double? LastReviewScore,
                        DateOnly? LastReviewDate,
                        DateOnly InitialDate);
public interface IFilterCustomerQueryUseCase : IUseCase<PaginationRequest<FilterCustomerQuery>, Paginated<FilterCustomerQueryResponse>> { }

public class FilterCustomerQueryUseCase : UseCaseBase<PaginationRequest<FilterCustomerQuery>, Paginated<FilterCustomerQueryResponse>>, IFilterCustomerQueryUseCase
{
    private readonly ICustomerRepository _customerRepository;

    public FilterCustomerQueryUseCase(ILogger<FilterCustomerQueryUseCase> logger,
                                    ICustomerRepository customerRepository)
        : base(logger, null)
    {
        _customerRepository = customerRepository;
    }

    protected override async Task<Paginated<FilterCustomerQueryResponse>> Execute(PaginationRequest<FilterCustomerQuery> command)
    {
        var (query, count) = await _customerRepository.FilterAsync(c =>
            command.Data.Name == null || c.CompanyName.ToLower().Contains(command.Data.Name.ToLower()),
            pageNumber: command.Page,
            pageSize: command.PageSize,
            command.Data.OrderByDesc ?? false,
            command.Data.OrderByLastReviewDate ?? false ? x => x.LastReviewDate! : x => x.CompanyName);

        if (query is null)
        {
            Fault(UseCaseErrorType.BadRequest, "Not found");
        }

        var customers = query is null ? new List<CustomerData>()
            : query.Select(c => new CustomerData(
                c.Id,
                c.CompanyName,
                c.ContactName,
                c.CompanyDocument,
                c.LastReviewScore,
                c.LastReviewDate,
                c.InitialDate)).ToList();


        var response = new FilterCustomerQueryResponse(customers);

        return new Paginated<FilterCustomerQueryResponse>()
        {
            Page = command.Page,
            TotalRegisterQty = count,
            Data = response
        };
    }
}