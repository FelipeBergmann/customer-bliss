using CustomerBliss.BuildingBlocks.UseCase;
using CustomerBliss.Domain.Entities.Customers;
using CustomerBliss.Domain.Repositories;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace CustomerBliss.Domain.UseCases.Customers;

public record CreateCustomerCommand(string Name, string ContactName, string CompanyDocument, DateOnly? InitialDate);
public record CreateCustomerCommandResponse(Guid Id);

public interface ICreateCustomerUseCase : IUseCase<CreateCustomerCommand, CreateCustomerCommandResponse>
{

}

public class CreateCustomerUseCase : UseCaseBase<CreateCustomerCommand, CreateCustomerCommandResponse>, ICreateCustomerUseCase
{
    private readonly ICustomerRepository _customerRepository;
    public CreateCustomerUseCase(ILogger<CreateCustomerUseCase> logger,
                                 
                                 ICustomerRepository customerRepository)
        : base(logger, null)
    {
        _customerRepository = customerRepository;
    }

    protected override async Task<CreateCustomerCommandResponse> Execute(CreateCustomerCommand command)
    {
        var customer = await _customerRepository.FindAsync(c => c.CompanyDocument == command.CompanyDocument);

        if (customer is not null)
        {
            Fault(UseCaseErrorType.BadRequest, $"{nameof(command.CompanyDocument)} must be unique");
        }

        var newCustomer = new Customer(Guid.NewGuid(), command.Name, command.ContactName, command.CompanyDocument, command.InitialDate ?? DateOnly.FromDateTime(DateTime.Today));
        await _customerRepository.AddAsync(newCustomer);
        await _customerRepository.SaveChangesAsync();

        return new CreateCustomerCommandResponse(newCustomer.Id);
    }
}
