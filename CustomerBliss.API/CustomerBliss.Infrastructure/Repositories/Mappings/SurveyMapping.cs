using CustomerBliss.Domain.Entities.Surveys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerBliss.Infrastructure.Repositories.Mappings;

internal class SurveyMapping : IEntityTypeConfiguration<Survey>
{
    public void Configure(EntityTypeBuilder<Survey> builder)
    {
        builder.ToTable("Surveys");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever().IsRequired();

        builder.HasMany(x => x.Reviews)
                .WithOne(x => x.Survey)
                .HasForeignKey(x => x.SurveyId);

        builder.HasIndex(x => x.Period, "IX_SURVEYS_PERIOD");
    }
}
