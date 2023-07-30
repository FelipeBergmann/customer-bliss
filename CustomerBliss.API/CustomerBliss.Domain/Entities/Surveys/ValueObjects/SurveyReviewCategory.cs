using System.Diagnostics.CodeAnalysis;

namespace CustomerBliss.Domain.Entities.Surveys.ValueObjects;

public struct SurveyReviewCategory
{
    public SurveyReviewCategory(double score)
    {
        Category = score switch
        {
            < 0 or > 10 => throw new ArgumentException($"{nameof(score)} must be between 0 and 10"),
            <= 6 => "Negative",
            <= 8 => "Neutral",
            _ => "Positive",
        };
    }

    public string Category { get; private set; }

    public const string Positive = "Positive";
    public const string Neutral = "Neutral";
    public const string Negative = "Negative";

    public override readonly bool Equals([NotNullWhen(true)] object? obj)
    {
        if (obj is not SurveyReviewCategory) return false;

        var other = (SurveyReviewCategory)obj;
        return Category.Equals(other.Category, StringComparison.CurrentCultureIgnoreCase);
    }

    public override readonly int GetHashCode() => Category.GetHashCode();

    public override readonly string? ToString() => Category;

    public static bool operator ==(SurveyReviewCategory left, SurveyReviewCategory right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(SurveyReviewCategory left, SurveyReviewCategory right)
    {
        return !(left == right);
    }

    public static bool operator ==(SurveyReviewCategory left, string right)
    {
        return left.Category.Equals(right, StringComparison.CurrentCultureIgnoreCase);
    }

    public static bool operator !=(SurveyReviewCategory left, string right)
    {
        return !(left == right);
    }
}