using CustomerBliss.API.DTO.Customer;
using CustomerBliss.Domain.Entities.Customers;
using CustomerBliss.Domain.Services.Customers;
using CustomerBliss.Domain.UseCases.Customers;
using Microsoft.AspNetCore.Mvc;

namespace CustomerBliss.API.Controllers;

[ApiVersion("1.0")]
[ApiController, Route("api/v{version:apiVersion}/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;

    public CustomerController(ILogger<CustomerController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "ListCustomer")]
    public async Task<ActionResult<ListCustomerResponse>> ListCustomer([FromQuery]string name, [FromServices] IFilterCustomerQueryUseCase useCase, [FromServices] ICustomerCategoryManager customerCategoryManager)
    {
        var queryResult = await useCase.Resolve(new FilterCustomerQuery(name));

        var customers = queryResult?.Customers.Select(c => 
            new CustomerDto(c.Id,
                            c.Name,
                            c.ContactName,
                            c.CompanyDocument,
                            c.LastReviewScore,
                            customerCategoryManager.ProcessCategory(c.LastReviewScore),
                            DateOnly.FromDateTime(DateTime.Today))).ToList();

        var response = new ListCustomerResponse(queryResult.TotalCustomerRegistered, customers);

        return response;
    }

    [HttpPost(Name = "CreateCustomer")]
    public async Task<ActionResult<CreateCustomerResponse>> CreateCustomer([FromBody] CreateCustomerRequest customer, [FromServices] ICreateCustomerUseCase createCustomerUseCase)
    {
        var response = await createCustomerUseCase.Resolve(new CreateCustomerCommand(customer.Name, customer.ContactName, customer.CompanyDocument, customer.InitialDate));

        return new CreateCustomerResponse(response.Id);
    }

}
