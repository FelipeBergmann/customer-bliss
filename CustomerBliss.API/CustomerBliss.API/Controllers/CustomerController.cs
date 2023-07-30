using CustomerBliss.API.DTO.Customer;
using Microsoft.AspNetCore.Mvc;

namespace CustomerBliss.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;

    public CustomerController(ILogger<CustomerController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "ListCustomer")]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> ListCustomer([FromQuery]string name)
    {
        return null;
    }

    [HttpPost(Name = "CreateCustomer")]
    public async Task<ActionResult<CustomerDto>> CreateCustomer([FromBody] CustomerRequest customer)
    {
        return null;
    }

}
