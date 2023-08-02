using CustomerBliss.Domain.Entities.Surveys.ValueObjects;

namespace CustomerBliss.Domain.UseCases.Surveys;

public record struct SurveyDto(Guid Id, int? Period, int? Positive, int? Neutral, int? Negative, double? NPS, SurveyStatus Status)
{
    public readonly int Total { get => Positive ?? 0 + Neutral ?? 0 + Negative ?? 0; }
}
