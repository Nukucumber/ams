using Fund.Core.Application.Abstractions;
using Fund.Core.Application.Ports;
using Microsoft.Extensions.DependencyInjection;

namespace Fund.Infrastructure.Implements;


internal sealed class Mediator(IServiceProvider serviceProvider)
    : ICommandMediator, IQueryMediator
{
    Task ICommandMediator.Send<TCommand>(TCommand command, CancellationToken ct)
    {
        var handler = serviceProvider.GetRequiredService<ICommandHandler<TCommand>>();
        return handler.Handle(command, ct);
    }

    Task<TResponse?> ICommandMediator.Send<TCommand, TResponse>(TCommand command, CancellationToken ct) where TResponse : default
    {
        var handler = serviceProvider.GetRequiredService<ICommandHandler<TCommand, TResponse>>();
        return handler.Handle(command, ct);
    }


    Task<TResponse> IQueryMediator.Send<TQuery, TResponse>(TQuery query, CancellationToken ct)
    {
        var handler = serviceProvider.GetRequiredService<IQueryHandler<TQuery, TResponse>>();
        return handler.Handle(query, ct);
    }

    IAsyncEnumerable<TResponse> IQueryMediator.CreateAsyncEnumerableStream<TQuery, TResponse>(TQuery query, CancellationToken ct)
    {
        var handler = serviceProvider.GetRequiredService<IAsyncEnumerableQueryHandler<TQuery, TResponse>>();
        return handler.Handle(query, ct);
    }

    Task<TResponse> IQueryMediator.CreateStream<TQuery, TResponse>(TQuery query, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}