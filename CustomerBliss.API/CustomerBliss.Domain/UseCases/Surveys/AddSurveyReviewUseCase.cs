using CustomerBliss.BuildingBlocks.UseCase;
using CustomerBliss.Domain.Entities.Customers;
using CustomerBliss.Domain.Entities.Surveys;
using CustomerBliss.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace CustomerBliss.Domain.UseCases.Surveys;

public record struct AddSurveyReviewUseCaseCommand(Guid surveyId, SurveyCustomerReviewOption[] Reviews);
public record struct SurveyCustomerReviewOption(Guid CustomerId, int ReviewScore, string Reason);
public record struct AddSurveyReviewUseCaseCommandResponse();

public interface IAddSurveyReviewUseCase : IUseCase<AddSurveyReviewUseCaseCommand, AddSurveyReviewUseCaseCommandResponse> { }

public class AddSurveyReviewUseCase : UseCaseBase<AddSurveyReviewUseCaseCommand, AddSurveyReviewUseCaseCommandResponse>, IAddSurveyReviewUseCase
{
    private readonly ISurveyRepository _surveyRepository;
    private readonly ICustomerRepository _customerRepository;
    public AddSurveyReviewUseCase(ILogger<AddSurveyReviewUseCase> logger, ISurveyRepository surveyRepository, ICustomerRepository customerRepository) : base(logger, null)
    {
        _surveyRepository = surveyRepository;
        _customerRepository = customerRepository;
    }

    protected async override Task<AddSurveyReviewUseCaseCommandResponse> Execute(AddSurveyReviewUseCaseCommand command)
    {
        var survey = await _surveyRepository.GetByIdAsync(command.surveyId);

        if (survey is null)
        {
            Fault(UseCaseErrorType.BadRequest, "Provided Survey Id was not found");
        }

        var customersToUpdate = new Customer[survey?.Reviews?.Count ?? 0];
        int customerIndex = 0;
        foreach (var review in survey!.Reviews)
        {
            var updatedReview = command.Reviews.Where(r => r.CustomerId == review.CustomerId).FirstOrDefault();
            review.ReviewScore = updatedReview.ReviewScore;
            review.Reason = updatedReview.Reason;

            var customer = await _customerRepository.GetByIdAsync(review.CustomerId);

            if (customer is null)
            {
                continue;
            }

            customer.LastReviewScore = review.ReviewScore;
            customer.LastReviewDate = DateOnly.FromDateTime(DateTime.Today);

            customersToUpdate[customerIndex] = customer;

            customerIndex++;
        }

        _surveyRepository.Update(survey);
        await _surveyRepository.SaveChangesAsync();

        _customerRepository.UpdateRange(customersToUpdate);
        await _customerRepository.SaveChangesAsync();

        return new();
    }
}

