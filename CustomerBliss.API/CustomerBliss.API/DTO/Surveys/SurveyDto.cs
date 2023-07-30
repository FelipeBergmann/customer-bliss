namespace CustomerBliss.API.DTO.Surveys;

public record struct SurveyCustomerRequest(Guid Id);
public record struct SurveyCustomerReviewRequest(Guid Id, int ReviewScore, string Reason);
public record struct SurveyDto(Guid Id, int Period, int Positive, int Neutral, int Negative, int Total, double NPS);