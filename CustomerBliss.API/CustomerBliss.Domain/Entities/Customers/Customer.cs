using CustomerBliss.Domain.Entities.Surveys;

namespace CustomerBliss.Domain.Entities.Customers;

public class Customer : IEntity
{
    protected Customer()
    {
            
    }
    public Customer(Guid id, string companyName, string contactName, string companyDocument, DateOnly initialDate)
    {
        Id = id;
        CompanyName = companyName;
        ContactName = contactName;
        CompanyDocument = companyDocument;
        InitialDate = initialDate;
        LastReviewScore = null;
    }

    public Guid Id { get; set; }
    public string CompanyName { get; set; }
    public string ContactName { get; set; }
    public string CompanyDocument { get; set; }
    public double? LastReviewScore { get; set; }
    public DateOnly InitialDate { get; set; }
    public DateOnly? LastReviewDate { get; set; }
    public virtual IEnumerable<SurveyCustomerReview>? Reviews { get; set; }
}
