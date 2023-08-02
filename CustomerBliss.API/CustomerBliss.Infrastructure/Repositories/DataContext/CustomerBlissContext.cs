using CustomerBliss.Domain.Entities.Customers;
using CustomerBliss.Domain.Entities.Surveys;
using CustomerBliss.Infrastructure.Repositories.Mappings.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CustomerBliss.Infrastructure.Repositories.DataContext;

public class CustomerBlissContext : DbContext
{
    public CustomerBlissContext(DbContextOptions<CustomerBlissContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Survey> Surveys { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyMappings();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      
        optionsBuilder.UseLazyLoadingProxies();

        var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
            builder.SetMinimumLevel(LogLevel.Debug);
        });

        optionsBuilder.UseLoggerFactory(loggerFactory);
        optionsBuilder.EnableSensitiveDataLogging();
    }
}
