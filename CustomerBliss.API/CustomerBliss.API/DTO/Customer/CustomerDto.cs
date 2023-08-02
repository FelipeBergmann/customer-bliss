using CustomerBliss.Domain.Entities.Customers;

namespace CustomerBliss.API.DTO.Customer;

public record struct CustomerDto(Guid Id,
                          string Name,
                          string ContactName,
                          string CompanyDocument,
                          double? LastReviewScore,
                          DateOnly? LastReviewDate,
                          CustomerCategory Category,
                          DateOnly? InitialDate);

public record struct ListCustomerResponse(int TotalCustomerCount, List<CustomerDto> Customers);
public record struct CreateCustomerRequest(string Name, string ContactName, string CompanyDocument, DateOnly InitialDate);
public record struct CreateCustomerResponse(Guid Id);