using Fund.Core.Application.Events;
using Fund.Core.Application.Ports;

namespace Fund.Infrastructure.Implements;

internal class EventPublisher : IEventPublisher
{
    private readonly IEventDispatcher _eventDispatcher;

    public EventPublisher(IEventDispatcher eventDispatcher) 
    {
        _eventDispatcher = eventDispatcher;
    }


    public async Task Publish(EventCollector eventCollector, CancellationToken ct = default)
    {
        foreach (var @event in eventCollector.Events)
        {
            await @event.DispatchAsync(_eventDispatcher, ct);
        }
    }
}