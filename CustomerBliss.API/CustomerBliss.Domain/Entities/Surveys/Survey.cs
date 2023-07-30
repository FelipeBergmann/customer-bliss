using CustomerBliss.Domain.Entities.Surveys.ValueObjects;

namespace CustomerBliss.Domain.Entities.Surveys;

public class Survey
{
    private double? _nps = null;
    private List<SurveyCustomerReview> _reviews;
    private bool _hasReviewsChange = false;

    public Survey(Guid id, int period, List<SurveyCustomerReview> reviews)
    {
        Id = id;
        Period = period;
        _reviews = reviews;
    }

    public Survey(int period, List<SurveyCustomerReview> reviews) : this(Guid.NewGuid(), period, reviews) { }

    public Guid Id { get; set; }
    public int Period { get; set; }
    public virtual double NPS => _hasReviewsChange || _nps is null ? SetNPS() : _nps.Value;
    public virtual SurveyTargetResult TargetResult => NPS switch
    {
        < 60 => SurveyTargetResult.Failed,
        < 80 => SurveyTargetResult.Tolerance,
        _ => SurveyTargetResult.Accomplished,
    };
    public IReadOnlyCollection<SurveyCustomerReview> Reviews { get => _reviews; }

    public Survey AddReview(SurveyCustomerReview review)
    {
        _reviews ??= new List<SurveyCustomerReview>();

        _reviews.Add(review);

        _hasReviewsChange = true;

        return this;
    }

    public Survey AddReviewRange(ICollection<SurveyCustomerReview> reviews)
    {
        _reviews ??= new List<SurveyCustomerReview>();

        _reviews.AddRange(reviews);

        _hasReviewsChange = true;

        return this;
    }

    private double SetNPS()
    {
        _hasReviewsChange = false;

        _nps = Math.Round(CalculateNPS(CountPositiveReviews(), CountNegativeReviews(), Reviews.Count), 2);
        return _nps.Value;
    }

    private static double CalculateNPS(int positive, int negative, int total) => (Convert.ToDouble(positive - negative) / total) * 100;

    private int CountPositiveReviews() => Reviews.Count(r => r.Category == SurveyReviewCategory.Positive);
    private int CountNegativeReviews() => Reviews.Count(r => r.Category == SurveyReviewCategory.Negative);
}