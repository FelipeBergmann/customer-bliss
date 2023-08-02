using CustomerBliss.API.DTO.Customer;
using CustomerBliss.BuildingBlocks.Pagination;
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
    public async Task<ActionResult<Paginated<ListCustomerResponse>>> ListCustomer([FromQuery] FilterCustomerQuery command,
        [FromServices] IFilterCustomerQueryUseCase useCase,
        [FromServices] IGetCountCustomerUseCase countCustomerUseCase,
        [FromServices] ICustomerCategoryManager customerCategoryManager,
        [FromQuery] int page = 0,
        [FromQuery] int pageSize = 50)
    {
        var queryResult = await useCase.Resolve(new PaginationRequest<FilterCustomerQuery>()
        {
            Page = page,
            PageSize = pageSize,
            Data = command
        });

        var customers = queryResult?.Data.Customers.Select(c =>
            new CustomerDto(c.Id,
                            c.Name,
                            c.ContactName,
                            c.CompanyDocument,
                            c.LastReviewScore,
                            c.LastReviewDate,
                            customerCategoryManager.ProcessCategory(c.LastReviewScore),
                            DateOnly.FromDateTime(DateTime.Today))).ToList();

        var totalCount = await countCustomerUseCase.Resolve(new GetCountCustomerCommand());

        var response = new ListCustomerResponse(totalCount?.Total ?? 0, customers);

        return Ok(new Paginated<ListCustomerResponse>()
        {
            Data = response
        });
    }

    [HttpPost(Name = "CreateCustomer")]
    public async Task<ActionResult<CreateCustomerResponse>> CreateCustomer([FromBody] CreateCustomerRequest customer, [FromServices] ICreateCustomerUseCase createCustomerUseCase)
    {
        var response = await createCustomerUseCase.Resolve(new CreateCustomerCommand(customer.Name, customer.ContactName, customer.CompanyDocument, customer.InitialDate));

        return Created("", new CreateCustomerResponse(response.Id));
    }

}
