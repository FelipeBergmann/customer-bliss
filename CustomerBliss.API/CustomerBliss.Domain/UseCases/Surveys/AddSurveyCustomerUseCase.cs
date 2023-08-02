using CustomerBliss.BuildingBlocks.UseCase;
using CustomerBliss.Domain.Repositories;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace CustomerBliss.Domain.UseCases.Surveys;

public record struct AddSurveyCustomerCommand(Guid surveyId, Guid[] customerIds);
public record struct AddSurveyCustomerCommandResponse();

public interface IAddSurveyCustomerUseCase : IUseCase<AddSurveyCustomerCommand, AddSurveyCustomerCommandResponse> { }
public class AddSurveyCustomerUseCase : UseCaseBase<AddSurveyCustomerCommand, AddSurveyCustomerCommandResponse>, IAddSurveyCustomerUseCase
{
    private readonly ISurveyRepository _surveyRepository;

    public AddSurveyCustomerUseCase(ILogger<AddSurveyCustomerUseCase> logger, ISurveyRepository surveyRepository) : base(logger, null)
    {
        this._surveyRepository = surveyRepository;
    }

    protected async override Task<AddSurveyCustomerCommandResponse> Execute(AddSurveyCustomerCommand command)
    {
        var survey = await _surveyRepository.GetByIdAsync(command.surveyId);

        if (survey is null)
        {
            Fault(UseCaseErrorType.BadRequest, "Provided Survey Id was not found");
        }

        var customerList = command.customerIds.Select(c => new Entities.Surveys.SurveyCustomerReview(survey!.Id, c, null, "")).ToList();

        if (survey!.Reviews.Count > 0)
        {
            customerList = customerList.Except(survey!.Reviews).ToList();
        }

        if(customerList.Count == 0)
        {
            Fault(UseCaseErrorType.BadRequest, "Provided customer list is not valid");
        }

        survey!.AddReviewRange(customerList);

        _surveyRepository.Update(survey);
        await _surveyRepository.SaveChangesAsync();

        return new();
    }
}
