using CustomerBliss.Domain.Entities.Surveys.ValueObjects;

namespace CustomerBliss.API.Test.Domain.Entities.SurveyReviewCategoryUnitTest;

public class SurveyReviewCategoryShould : SurveyReviewCategoryUnitTestBase
{
    [Trait("category", "unit")]
    [Theory(DisplayName = "SurveyReviewCategory - new - Should set correct category")]
    [InlineData(0, SurveyReviewCategory.Negative)]
    [InlineData(1, SurveyReviewCategory.Negative)]
    [InlineData(2, SurveyReviewCategory.Negative)]
    [InlineData(3, SurveyReviewCategory.Negative)]
    [InlineData(4, SurveyReviewCategory.Negative)]
    [InlineData(5, SurveyReviewCategory.Negative)]
    [InlineData(6, SurveyReviewCategory.Negative)]
    [InlineData(7, SurveyReviewCategory.Neutral)]
    [InlineData(8, SurveyReviewCategory.Neutral)]
    [InlineData(9, SurveyReviewCategory.Positive)]
    [InlineData(10, SurveyReviewCategory.Positive)]
    public void SurveyReviewCategory_New_ShouldSetCorrectCategory(double score, string expectedCategory)
    {
        //arrange
        //act
        var reviewCategory = new SurveyReviewCategory(score);

        //assert
        Assert.Equal(expectedCategory, reviewCategory.Category);
    }


    [Trait("category", "unit")]
    [Theory(DisplayName = "SurveyReviewCategory - new - Should throw ArgumentException when score is out of range (0-10)")]
    [InlineData(10.01)]
    [InlineData(-0.01)]
    public void SurveyReviewCategory_New_ShouldThrowArgumentExceptionWhenScoreIsOutOfRange(double score)
    {
        //arrange
        //act
        var result = Assert.Throws<ArgumentException>(() => new SurveyReviewCategory(score));

        //assert
        Assert.NotNull(result);
        Assert.IsType<ArgumentException>(result);
       
    }
}