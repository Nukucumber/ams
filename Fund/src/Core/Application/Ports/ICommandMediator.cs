using Fund.Core.Application.Abstractions;

namespace Fund.Core.Application.Ports;

public interface ICommandMediator
{
    Task Send<TCommand>(
        TCommand command,
        CancellationToken ct = default)
        where TCommand : ICommand;


    Task<TResponse?> Send<TCommand, TResponse>(
        TCommand command,
        CancellationToken ct = default)
        where TCommand : ICommand<TResponse>;    
}