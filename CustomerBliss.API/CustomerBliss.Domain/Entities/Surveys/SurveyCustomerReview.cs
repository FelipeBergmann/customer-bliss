using CustomerBliss.Domain.Entities.Customers;
using CustomerBliss.Domain.Entities.Surveys.ValueObjects;

namespace CustomerBliss.Domain.Entities.Surveys;

public class SurveyCustomerReview
{
    protected SurveyCustomerReview()
    {

    }
    public SurveyCustomerReview(Guid surveyId, Guid customerId, int? reviewScore, string reason)
    {
        SurveyId = surveyId;
        CustomerId = customerId;
        ReviewScore = reviewScore;
        Reason = reason;
    }

    private SurveyReviewCategory? _surveyCategory = null;

    public Guid SurveyId { get; set; }
    public virtual Survey Survey { get; set; }
    public Guid CustomerId { get; set; }
    public virtual Customer Customer { get; set; }
    public int? ReviewScore { get; set; }
    public string Reason { get; set; }
    public SurveyReviewCategory Category => _surveyCategory ?? SetSurveyCategory(ReviewScore);

    private SurveyReviewCategory SetSurveyCategory(int? reviewScore)
    {
        _surveyCategory ??= new(reviewScore);
        return _surveyCategory.Value;
    }
}
