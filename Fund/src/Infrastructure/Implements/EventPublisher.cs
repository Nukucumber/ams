using Fund.Core.Ports;
using Fund.Core.Services;

namespace Fund.Infrastructure.Implements;

internal class EventPublisher : EventPublisherAbstract
{
    private readonly IEventDispatcher _eventDispatcher;

    public EventPublisher(EventCollector eventCollector, IEventDispatcher eventDispatcher) : base(eventCollector)
    {
        _eventDispatcher = eventDispatcher;
    }


    public override async Task Publish(CancellationToken ct = default)
    {
        foreach (var @event in _eventCollector.Events)
        {
            await @event.DispatchAsync(_eventDispatcher, ct);
        }
        _eventCollector.Free();
    }
}