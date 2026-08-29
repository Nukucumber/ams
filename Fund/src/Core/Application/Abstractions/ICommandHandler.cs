namespace Fund.Core.Application.Abstractions;

public interface ICommandHandler<TCommand>
where TCommand : ICommand
{
    public Task Handle(TCommand command, CancellationToken ct = default);
}


public interface ICommandHandler<TCommand, TResponse>
where TCommand : ICommand<TResponse>
{
    public Task<TResponse?> Handle(TCommand command, CancellationToken ct = default);
}