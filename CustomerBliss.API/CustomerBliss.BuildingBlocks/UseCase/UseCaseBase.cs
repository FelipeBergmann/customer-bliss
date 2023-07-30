using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CustomerBliss.BuildingBlocks.UseCase
{
    public abstract class AbstractUseCase<TCommand>
    {
        protected readonly List<UseCaseError> _useCaseError = new List<UseCaseError>();
        public bool IsFaulted { get => _useCaseError.Any(); }

        public ICollection<UseCaseError> GetErrors() => _useCaseError;

        protected virtual async Task ValidateCommandInput(TCommand command, AbstractValidator<TCommand> validator)
        {
            var validationResult = await validator.ValidateAsync(command);

            if (!validationResult.IsValid)
                Fault(UseCaseErrorType.BadRequest, SerializeValdationErrors(validationResult.Errors));
        }

        public void Fault(UseCaseErrorType code, string message)
        {
            throw new UseCaseException(code, message);
        }

        protected string SerializeValdationErrors(List<ValidationFailure> errors)
        {
            return JsonSerializer.Serialize(errors.Select(x => new { Property = x.PropertyName, Error = x.ErrorMessage }));
        }
    }

    public abstract class UseCaseBase<TCommand> : AbstractUseCase<TCommand>, IUseCase<TCommand>
    {
        protected readonly ILogger _logger;
        protected readonly ExecutionLogList _executionLog = new ExecutionLogList();
        protected readonly AbstractValidator<TCommand>? _validator;

        protected UseCaseBase(ILogger logger, AbstractValidator<TCommand>? validator)
        {
            _logger = logger;
            _validator = validator;
        }

        public async Task Resolve(TCommand command)
        {
            _executionLog.AddInfo($"Starting to resolve {typeof(TCommand)}")
                         .AddInfo($"Received command: {JsonSerializer.Serialize(command)}");

            try
            {
                if (_validator != null)
                {
                    _executionLog.AddDebug("Initializing command validation");

                    await ValidateCommandInput(command, _validator);

                    _executionLog.AddDebug("Provided command is valid");
                }

                _executionLog.AddDebug("Initializing command execution");
                await Execute(command);
                _executionLog.AddInfo($"Resolved completed {typeof(TCommand)}");
            }
            catch (UseCaseException ucex)
            {
                _useCaseError.Add(new UseCaseError(ucex.Code, ucex.Message));
                _executionLog.AddError(ucex.Message);
            }
            catch (Exception ex)
            {
                _useCaseError.Add(new UseCaseError(UseCaseErrorType.InternalError, ex.Message));
                _executionLog.AddError(ex.Message);
            }
            finally
            {
                _logger.LogInformation(message: _executionLog.ToString());
            }
        }

        protected abstract Task Execute(TCommand command);
    }

    public abstract class UseCaseBase<TCommand, TOut> : AbstractUseCase<TCommand>, IUseCase<TCommand, TOut>
    {
        protected readonly ILogger _logger;
        protected readonly AbstractValidator<TCommand>? _validator;
        protected readonly ExecutionLogList _executionLog = new ExecutionLogList();

        protected UseCaseBase(ILogger logger, AbstractValidator<TCommand>? validator)
        {
            _logger = logger;
            _validator = validator;
        }

        public async Task<TOut> Resolve(TCommand command)
        {
            _executionLog.AddInfo($"Starting to resolve {typeof(TCommand)}")
                        .AddInfo($"Received command: {JsonSerializer.Serialize(command)}");

            try
            {
                if (_validator != null)
                {
                    _executionLog.AddDebug("Initializing command validation");

                    await ValidateCommandInput(command, _validator);

                    _executionLog.AddDebug("Provided command is valid");
                }

                _executionLog.AddDebug("Initializing command execution");
                var result = await Execute(command);
                _executionLog.AddInfo($"Resolved completed {typeof(TCommand)}");

                return result;
            }
            catch (UseCaseException ucex)
            {
                _useCaseError.Add(new UseCaseError(ucex.Code, ucex.Message));
                _executionLog.AddError(ucex.Message);
            }
            catch (Exception ex)
            {
                _useCaseError.Add(new UseCaseError(UseCaseErrorType.InternalError, ex.Message));
                _executionLog.AddError(ex.Message);
            }
            finally
            {
                _logger.LogInformation(message: _executionLog.ToString());
            }

            return default!;
        }

        protected abstract Task<TOut> Execute(TCommand command);
    }
}