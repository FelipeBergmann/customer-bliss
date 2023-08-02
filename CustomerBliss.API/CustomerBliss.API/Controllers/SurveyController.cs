using CustomerBliss.BuildingBlocks.Pagination;
using CustomerBliss.Domain.UseCases.Surveys;
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
    public async Task<ActionResult<IEnumerable<DTO.Surveys.SurveyDto>>> ListSurvey([FromServices] IListSurveyUseCase useCase,
        [FromQuery] int page = 0, [FromQuery] int pageSize = 50)
    {
        var result = await useCase.Resolve(new PaginationRequest<ListSurveyCommand>()
        {
            Data = new ListSurveyCommand(),
            PageSize = pageSize,
            Page = page
        });

        return Ok(result);
    }

    [HttpGet("{period}", Name = "FindSurvey")]
    public async Task<ActionResult<DTO.Surveys.SurveyDto>> FindSurvey([FromRoute] int period, [FromServices] IFindSurveyUseCase useCase)
    {
        var result = await useCase.Resolve(new FindSurveyCommand(period));

        return Ok(new DTO.Surveys.SurveyDto(result.Survey.Id, result.Survey.Period, result.Survey.Positive, result.Survey.Neutral, result.Survey.Negative, result.Survey.Total, result.Survey.NPS));
    }

    [HttpPost(Name = "CreateSurvey")]
    public async Task<ActionResult<DTO.Surveys.SurveyDto>> CreateSurvey([FromBody] int period, [FromServices] ICreateSurveyUseCase useCase)
    {
        var result = await useCase.Resolve(new CreateSurveyCommand(period));

        return Ok(new DTO.Surveys.SurveyDto(result.id));
    }

    [HttpPost("{surveyId:guid}/Customer", Name = "AddSurveyCustomer")]
    public async Task<ActionResult<DTO.Surveys.SurveyDto>> AddSurveyCustomer([FromRoute] Guid surveyId, [FromBody] Guid[] customersId, [FromServices] IAddSurveyCustomerUseCase useCase)
    {
        var result = await useCase.Resolve(new AddSurveyCustomerCommand(surveyId, customersId));

        return Ok(result);
    }

    [HttpPost("{surveyId:guid}/Review", Name = "SetCustomerReview")]
    public async Task<ActionResult<DTO.Surveys.SurveyDto>> SetCustomerReview([FromRoute] Guid surveyId, [FromBody] SurveyCustomerReviewOption[] customerReviews, [FromServices] IAddSurveyReviewUseCase useCase)
    {
        var result = await useCase.Resolve(new AddSurveyReviewUseCaseCommand(surveyId, customerReviews));

        return Ok(result);
    }
}