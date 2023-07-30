using CustomerBliss.Domain.Entities.Surveys;
using Bogus;

namespace CustomerBliss.API.Test.Domain.Entities.SurveyUnitTests;
public abstract class SurveyUnitTestBase
{
    protected Faker _faker = new();
    protected static SurveyCustomerReview NewPositiveCustomerReview(Guid surveyId, Guid customerId) => new(surveyId, customerId, 9, "");
    protected static SurveyCustomerReview NewNeutralCustomerReview(Guid surveyId, Guid customerId) => new(surveyId, customerId, 7, "");
    protected static SurveyCustomerReview NewNegativeCustomerReview(Guid surveyId, Guid customerId) => new(surveyId, customerId, 6, "");

    protected int RandomPeriod() => _faker.Random.Int(min: 202301, max: 202312);
}
