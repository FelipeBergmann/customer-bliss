using CustomerBliss.BuildingBlocks.UseCase;
using CustomerBliss.Domain.Entities.Surveys;
using CustomerBliss.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace CustomerBliss.Domain.UseCases.Surveys;

public record CreateSurveyCommand(int period);
public record CreateSurveyCommandResponse(Guid id);
public interface ICreateSurveyUseCase : IUseCase<CreateSurveyCommand, CreateSurveyCommandResponse>
{

}
public class CreateSurveyUseCase : UseCaseBase<CreateSurveyCommand, CreateSurveyCommandResponse>, ICreateSurveyUseCase
{
   private readonly ISurveyRepository _surveyRepository;

    public CreateSurveyUseCase(ILogger<CreateSurveyUseCase> logger, ISurveyRepository surveyRepository) : base(logger, null)
    {
        _surveyRepository = surveyRepository;
    }

    protected async override Task<CreateSurveyCommandResponse> Execute(CreateSurveyCommand command)
    {
        var existingSurvey = await _surveyRepository.AnyAsync(s => s.Period == command.period);

        if (existingSurvey)
        {
            Fault(UseCaseErrorType.BadRequest, $"A survey for the period {command.period} already exists");
        }

        var newSurvey = new Survey(command.period);

        await _surveyRepository.AddAsync(newSurvey);
        await _surveyRepository.SaveChangesAsync();

        return new CreateSurveyCommandResponse(newSurvey.Id);
    }
}
