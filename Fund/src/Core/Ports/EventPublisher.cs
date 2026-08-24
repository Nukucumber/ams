using Fund.Core.Services;

namespace Fund.Core.Ports;


public abstract class EventPublisherAbstract
{
    protected readonly EventCollector _eventCollector;

    protected EventPublisherAbstract(EventCollector eventCollector)
    {
        _eventCollector = eventCollector;
    }


    public abstract Task Publish(CancellationToken ct = default);
}