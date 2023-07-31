using Microsoft.EntityFrameworkCore;

namespace CustomerBliss.Infrastructure.Repositories.Mappings.Extensions;

internal static class MappingExtension
{
    internal static ModelBuilder ApplyMappings(this ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerMapping());
        modelBuilder.ApplyConfiguration(new SurveyMapping());
        modelBuilder.ApplyConfiguration(new SurveyCustomerReviewMapping());

        return modelBuilder;
    }
}
