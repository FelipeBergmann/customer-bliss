using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerBliss.BuildingBlocks.UseCase
{
    public interface IUseCase<TCommand>
    {
        public Task Resolve(TCommand command);

        public void Fault(UseCaseErrorType code, string message);

        public bool IsFaulted { get; }

        public ICollection<UseCaseError> GetErrors();

    }
    public interface IUseCase<TCommand, TOut>
    {
        public Task<TOut> Resolve(TCommand command);

        public void Fault(UseCaseErrorType code, string message);

        public bool IsFaulted { get; }

        public ICollection<UseCaseError> GetErrors();
    }
}