using CustomerBliss.Domain.Entities.Customers;
using CustomerBliss.Domain.Entities.Surveys;
using CustomerBliss.Infrastructure.Repositories.Mappings.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CustomerBliss.Infrastructure.Repositories.DataContext;

public class CustomerBlissContext : DbContext
{
    public CustomerBlissContext(DbContextOptions<CustomerBlissContext> options) : base(options)
    {
        this.ChangeTracker.LazyLoadingEnabled = false;
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Survey> Surveys { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyMappings();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.LogTo(Console.WriteLine);
}
