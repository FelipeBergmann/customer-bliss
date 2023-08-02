using CustomerBliss.BuildingBlocks.Pagination;
using CustomerBliss.BuildingBlocks.UseCase;
using CustomerBliss.Domain.Entities.Surveys.ValueObjects;
using CustomerBliss.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace CustomerBliss.Domain.UseCases.Surveys;

public record struct ListSurveyCommand();
public record class ListSurveyCommandResponse(List<SurveyDto> Surveys);

public interface IListSurveyUseCase : IUseCase<PaginationRequest<ListSurveyCommand>, Paginated<ListSurveyCommandResponse>> { }

public class ListSurveyUseCase : UseCaseBase<PaginationRequest<ListSurveyCommand>, Paginated<ListSurveyCommandResponse>>, IListSurveyUseCase
{
    private readonly ISurveyRepository _surveyRepository;

    public ListSurveyUseCase(ILogger<FindSurveyUseCase> logger, ISurveyRepository surveyRepository) : base(logger, null)
    {
        _surveyRepository = surveyRepository;
    }

    protected async override Task<Paginated<ListSurveyCommandResponse>> Execute(PaginationRequest<ListSurveyCommand> command)
    {
        var (surveys, count) = await _surveyRepository.GetAllAsync(command.Page, command.PageSize);

        if (surveys is null)
        {
            return new Paginated<ListSurveyCommandResponse>();
        }

        var surveysResponse = surveys.Select(s => new SurveyDto(s.Id,
            s.Period,
            s.Reviews?.Count(r => r.Category == SurveyReviewCategory.Positive),
            s.Reviews?.Count(r => r.Category == SurveyReviewCategory.Neutral),
            s.Reviews?.Count(r => r.Category == SurveyReviewCategory.Negative),
            s.NPS,
            s.Status)).ToList();

        return new Paginated<ListSurveyCommandResponse>()
        {
            Data = new ListSurveyCommandResponse(surveysResponse),
            TotalRegisterQty = count,
            Page = command.Page
        };
    }
}
