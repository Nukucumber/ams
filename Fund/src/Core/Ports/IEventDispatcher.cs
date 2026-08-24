using Fund.Core.Abstractions;

namespace Fund.Core.Ports;

public interface IEventDispatcher
{
    public Task Dispatch<TEvent>(TEvent @event, CancellationToken ct = default)
    where TEvent : EventBase;
}
