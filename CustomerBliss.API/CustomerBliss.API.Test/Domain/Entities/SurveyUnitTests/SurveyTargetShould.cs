using CustomerBliss.Domain.Entities.Surveys;
using Moq;

namespace CustomerBliss.API.Test.Domain.Entities.SurveyUnitTests;
public class SurveyTargetShould : SurveyUnitTestBase
{
    [Trait("category", "unit")]
    [Theory(DisplayName = "Survey - Target - Should set category correctly")]
    [InlineData(59, SurveyTargetResult.Failed)]
    [InlineData(60, SurveyTargetResult.Tolerance)]
    [InlineData(79.99d, SurveyTargetResult.Tolerance)]
    [InlineData(80, SurveyTargetResult.Accomplished)]
    public void Survey_Target_ShouldSetCategoryCorrectly(double nps, SurveyTargetResult expectedTargetResult)
    {
        //arrange
        var mockSurvey = new Mock<Survey>();
        mockSurvey.Setup(s => s.NPS).Returns(nps);
        mockSurvey.Setup(s => s.TargetResult).CallBase();

        //act
        var targetResult = mockSurvey.Object.TargetResult;

        //assert
        Assert.Equal(expectedTargetResult, targetResult);
    }
}