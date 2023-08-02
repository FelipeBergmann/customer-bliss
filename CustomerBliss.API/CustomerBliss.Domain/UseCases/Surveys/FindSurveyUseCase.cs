using CustomerBliss.BuildingBlocks.UseCase;
using CustomerBliss.Domain.Entities.Surveys.ValueObjects;
using CustomerBliss.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace CustomerBliss.Domain.UseCases.Surveys;

public record struct FindSurveyCommand(int period);
public record struct FindSurveyCommandResponse(SurveyDto Survey);

public interface IFindSurveyUseCase : IUseCase<FindSurveyCommand, FindSurveyCommandResponse> { }
public class FindSurveyUseCase : UseCaseBase<FindSurveyCommand, FindSurveyCommandResponse>, IFindSurveyUseCase
{
    private readonly ISurveyRepository _surveyRepository;

    public FindSurveyUseCase(ILogger<FindSurveyUseCase> logger, ISurveyRepository surveyRepository) : base(logger, null)
    {
        _surveyRepository = surveyRepository;
    }

    protected async override Task<FindSurveyCommandResponse> Execute(FindSurveyCommand command)
    {
        var survey = await _surveyRepository.FindAsync(s => s.Period == command.period);

        if(survey is null)
        {
            return new FindSurveyCommandResponse();
        }

        var positiveReviews = survey.Reviews?.Count(r => r.Category == SurveyReviewCategory.Positive);
        var neutralReviews = survey.Reviews?.Count(r => r.Category == SurveyReviewCategory.Neutral);
        var negativeReviews = survey.Reviews?.Count(r => r.Category == SurveyReviewCategory.Negative);

        return new FindSurveyCommandResponse(new SurveyDto(survey.Id, survey.Period, positiveReviews, neutralReviews, negativeReviews,  survey.NPS, survey.Status));
    }
}


