using CustomerBliss.Domain.Entities.Surveys;
using CustomerBliss.Domain.Repositories;
using CustomerBliss.Infrastructure.Repositories.DataContext;

namespace CustomerBliss.Infrastructure.Repositories.Customers;

internal class SurveyRepository : RepositoryBase<Survey>, ISurveyRepository
{
    public SurveyRepository(CustomerBlissContext dbContext) : base(dbContext)
    {
    }
}