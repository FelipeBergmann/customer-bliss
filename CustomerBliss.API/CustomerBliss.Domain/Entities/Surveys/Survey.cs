using CustomerBliss.Domain.Entities.Surveys.ValueObjects;

namespace CustomerBliss.Domain.Entities.Surveys;

public class Survey : IEntity
{
    private double? _nps = null;
    private List<SurveyCustomerReview> _reviews;
    private bool _hasReviewsChange = false;

    protected Survey()
    {

    }
    public Survey(Guid id, int period, List<SurveyCustomerReview>? reviews = null)
    {
        Id = id;
        Period = period;
        _reviews = reviews ?? new();
    }

    public Survey(int period, List<SurveyCustomerReview>? reviews = null) : this(Guid.NewGuid(), period, reviews) { }

    public Guid Id { get; set; }
    public int Period { get; set; }
    public virtual double NPS => _hasReviewsChange || _nps is null ? SetNPS() : _nps.Value;
    public virtual SurveyTargetResult TargetResult => NPS switch
    {
        < 60 => SurveyTargetResult.Failed,
        < 80 => SurveyTargetResult.Tolerance,
        _ => SurveyTargetResult.Accomplished,
    };
    public virtual IReadOnlyCollection<SurveyCustomerReview> Reviews => _reviews;
    public SurveyStatus Status { get; set; } = SurveyStatus.Initialized;

    public Survey AddReview(SurveyCustomerReview review)
    {
        if (Status == SurveyStatus.Finalized)
            throw new ApplicationException("This survey is finalized you cannot add new reviews");

        _reviews ??= new List<SurveyCustomerReview>();

        _reviews.Add(review);

        _hasReviewsChange = true;

        return this;
    }

    public Survey AddReviewRange(ICollection<SurveyCustomerReview> reviews)
    {
        if (Status == SurveyStatus.Finalized)
            throw new ApplicationException("This survey is finalized you cannot add new reviews");

        _reviews ??= new List<SurveyCustomerReview>();

        _reviews.AddRange(reviews);

        _hasReviewsChange = true;

        return this;
    }

    public Survey ClearReviews()
    {
        if (_reviews is not null)
        {
            _reviews.Clear();
            _hasReviewsChange = true;
        }
        return this;
    }

    public Survey FinalizeSurvey()
    {
        Status = SurveyStatus.Finalized;

        return this;
    }

    private double SetNPS()
    {
        _hasReviewsChange = false;

        if (Reviews is null || Reviews.Count < 1)
        {
            _nps = null;
            return 0d;
        }

        _nps = Math.Round(CalculateNPS(CountPositiveReviews(), CountNegativeReviews(), Reviews.Count), 2);
        return _nps.Value;
    }

    private static double CalculateNPS(int positive, int negative, int total) => (Convert.ToDouble(positive - negative) / total) * 100;

    private int CountPositiveReviews() => Reviews?.Count(r => r.Category == SurveyReviewCategory.Positive) ?? 0;
    private int CountNegativeReviews() => Reviews?.Count(r => r.Category == SurveyReviewCategory.Negative) ?? 0;
}