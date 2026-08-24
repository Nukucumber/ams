using Fund.Core.Abstractions;
using Fund.Core.Ports;
using Fund.Infrastructure.Ports;
using Microsoft.Extensions.DependencyInjection;

namespace Fund.Infrastructure.Implements;


internal class EventDispatcher : IEventDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public EventDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task Dispatch<TEvent>(TEvent @event, CancellationToken ct = default) where TEvent : EventBase
    {
        var handlers = _serviceProvider.GetServices<IEventHandler<TEvent>>();
        foreach (var handler in handlers)
        {
            await handler.Handle(@event, ct);
        }
    }
}