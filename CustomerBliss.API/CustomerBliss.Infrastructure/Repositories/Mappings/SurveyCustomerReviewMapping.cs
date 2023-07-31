using CustomerBliss.Domain.Entities.Surveys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerBliss.Infrastructure.Repositories.Mappings;

internal class SurveyCustomerReviewMapping : IEntityTypeConfiguration<SurveyCustomerReview>
{
    public void Configure(EntityTypeBuilder<SurveyCustomerReview> builder)
    {
        builder.ToTable("SurveysCustomerReview");

        builder.HasKey(x => new { x.SurveyId, x.CustomerId});

        builder.Ignore(x => x.Category);

        builder.HasOne(x => x.Survey)
               .WithMany(x => x.Reviews)
               .HasForeignKey(x => x.SurveyId);

        builder.HasOne(x => x.Customer)
               .WithMany(x => x.Reviews)
               .HasForeignKey(x => x.CustomerId);
    }
}