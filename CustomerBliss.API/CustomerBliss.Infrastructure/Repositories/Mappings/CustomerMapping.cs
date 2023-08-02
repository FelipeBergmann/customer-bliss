using CustomerBliss.Domain.Entities.Customers;
using CustomerBliss.Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerBliss.Infrastructure.Repositories.Mappings;

internal class CustomerMapping : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever().IsRequired();

        builder.Property(x => x.CompanyName).IsRequired();
        builder.Property(x => x.ContactName).IsRequired();

        builder.Property(x => x.InitialDate).HasConversion<DateOnlyConverter, DateOnlyComparer>();
        builder.Property(x => x.LastReviewDate).IsRequired(false).HasConversion<DateOnlyConverter, DateOnlyComparer>();

        builder.Property(x => x.CompanyDocument).IsRequired(false);

        builder.HasIndex(x => x.CompanyName, "IX_CUSTOMERS_NAME");
    }
}
