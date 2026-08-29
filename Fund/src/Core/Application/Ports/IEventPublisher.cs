using Fund.Core.Application.Events;

namespace Fund.Core.Application.Ports;


public interface IEventPublisher
{
    public Task Publish(EventCollector eventCollector, CancellationToken ct = default);
}