using CustomerBliss.BuildingBlocks.UseCase;
using CustomerBliss.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace CustomerBliss.Domain.UseCases.Customers;

public record GetCountCustomerCommand() { }
public record GetCountCustomerCommandResponse(int Total);

public interface IGetCountCustomerUseCase : IUseCase<GetCountCustomerCommand, GetCountCustomerCommandResponse> { }

public class GetCountCustomerUseCase : UseCaseBase<GetCountCustomerCommand, GetCountCustomerCommandResponse>, IGetCountCustomerUseCase
{
    private readonly ICustomerRepository _customerRepository;

    public GetCountCustomerUseCase(ILogger<GetCountCustomerUseCase> logger, ICustomerRepository customerRepository) : base(logger, null)
    {
        _customerRepository = customerRepository;
    }

    protected async override Task<GetCountCustomerCommandResponse> Execute(GetCountCustomerCommand command)
    {
        var totalCount = await _customerRepository.CountAsync();

        return new GetCountCustomerCommandResponse(totalCount);
    }
}