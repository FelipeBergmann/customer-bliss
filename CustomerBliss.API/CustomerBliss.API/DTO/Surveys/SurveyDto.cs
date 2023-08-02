namespace CustomerBliss.API.DTO.Surveys;

public record struct SurveyCustomerReviewRequest(Guid CustomerId, int ReviewScore, string Reason);
public record struct SurveyDto(Guid Id, int? Period = null, int? Positive = null, int? Neutral = null, int? Negative = null, int? Total = null, double? NPS = null);