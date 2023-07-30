namespace CustomerBliss.API.DTO.Customer;

public record struct CustomerDto(Guid Id,
                          string Name,
                          string ContactName,
                          string CompanyDocument,
                          int LastReviewScore,
                          CustomerCategory Category,
                          string TotalCustomers,
                          DateOnly InitialDate);

public record struct CustomerRequest(string Name, string ContactName, string CompanyDocument, DateOnly InitialDate);
