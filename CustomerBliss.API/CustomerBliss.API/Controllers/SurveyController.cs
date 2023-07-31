using CustomerBliss.API.DTO.Surveys;
using Microsoft.AspNetCore.Mvc;

namespace CustomerBliss.API.Controllers;

[ApiVersion("1.0")]
[ApiController, Route("api/v{version:apiVersion}/[controller]")]
public class SurveyController : ControllerBase
{
    private readonly ILogger<SurveyController> _logger;

    public SurveyController(ILogger<SurveyController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "ListSurvey")]
    public async Task<ActionResult<IEnumerable<SurveyDto>>> ListSurvey()
    {
        return null;
    }

    [HttpGet("{period}", Name = "FindSurvey")]
    public async Task<ActionResult<SurveyDto>> FindSurvey([FromRoute] int period)
    {
        return null;
    }

    [HttpPost(Name = "CreateSurvey")]
    public async Task<ActionResult<SurveyDto>> CreateSurvey([FromBody] int period)
    {
        return null;
    }

    [HttpPost("{surveyId:guid}/Customer", Name = "AddSurveyCustomer")]
    public async Task<ActionResult<SurveyDto>> AddSurveyCustomer([FromRoute] Guid surveyId, [FromBody] SurveyCustomerRequest[] customers)
    {
        return null;
    }

    [HttpPost("{surveyId:guid}/Review", Name = "SetCustomerReview")]
    public async Task<ActionResult<SurveyDto>> SetCustomerReview([FromRoute] Guid surveyId, [FromBody] SurveyCustomerReviewRequest[] customerReviews)
    {
        return null;
    }
}