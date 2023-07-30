using CustomerBliss.Domain.Entities.Surveys;

namespace CustomerBliss.API.Test.Domain.Entities.SurveyUnitTests;

public class SurveyNPSShould : SurveyUnitTestBase
{
    [Trait("category", "unit")]
    [Theory(DisplayName = "Survey - NPS - Should calculate NPS correctly")]
    [InlineData(19, 4, 2, 68)]
    [InlineData(80, 10, 10, 70)]
    [InlineData(60, 30, 10, 50)]
    [InlineData(36, 50, 40, -3.17d)]
    public void Survey_NPS_ShouldCalculateNPSCorrectly(int totalPositive, int totalNeutral, int totalNegative, double expectedNPS)
    {
        //arrange
        Guid surveyId = Guid.NewGuid();
        Guid customerId = Guid.NewGuid();
        var reviews = new List<SurveyCustomerReview>();
        reviews.AddRange(Enumerable.Range(0, totalPositive).Select(item => NewPositiveCustomerReview(surveyId, customerId)));
        reviews.AddRange(Enumerable.Range(0, totalNeutral).Select(item => NewNeutralCustomerReview(surveyId, customerId)));
        reviews.AddRange(Enumerable.Range(0, totalNegative).Select(item => NewNegativeCustomerReview(surveyId, customerId)));

        var survey = new Survey(RandomPeriod(), reviews);

        //act
        var nps = survey.NPS;

        //assert
        Assert.Equal(expectedNPS, nps);
    }

    [Trait("category", "unit")]
    [Fact(DisplayName = "Survey - AddReview - Should recalculate NPS when reviews change")]
    public void Survey_AddReview_ShouldRecalculateNPSWhenReviewsChange()
    {
        //arrange
        Guid surveyId = Guid.NewGuid();
        Guid customerId = Guid.NewGuid();
        var reviews = new List<SurveyCustomerReview>();
        reviews.AddRange(Enumerable.Range(0, _faker.Random.Int(10, 20)).Select(item => NewPositiveCustomerReview(surveyId, customerId)));
        reviews.AddRange(Enumerable.Range(0, _faker.Random.Int(10, 20)).Select(item => NewNeutralCustomerReview(surveyId, customerId)));
        reviews.AddRange(Enumerable.Range(0, _faker.Random.Int(10, 20)).Select(item => NewNegativeCustomerReview(surveyId, customerId)));

        var survey = new Survey(RandomPeriod(), reviews);

        //act
        var nps = survey.NPS;

        foreach(var i in Enumerable.Range(0, _faker.Random.Int(20, 30)))
        {
            survey.AddReview(NewPositiveCustomerReview(surveyId, customerId));
        }

        //assert
        Assert.NotEqual(nps, survey.NPS);
    }
}
