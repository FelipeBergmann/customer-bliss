namespace CustomerBliss.Domain.Entities.Customers;

public class Customer
{
    public Customer(Guid id, string companyName,string contactName, string companyDocument, DateOnly initialDate)
    {
        Id = id;
        CompanyName = companyName;
        ContactName = contactName;
        CompanyDocument = companyDocument;
        InitialDate = initialDate;
    }

    public Guid Id { get; set; }
    public string CompanyName { get; set; }
    public string ContactName { get; set; }
    public string CompanyDocument { get; set; }
    public DateOnly InitialDate { get; set; }
}
