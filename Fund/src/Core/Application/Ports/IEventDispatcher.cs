using Fund.Core.Application.Abstractions;

namespace Fund.Core.Application.Ports;

public interface IEventDispatcher
{
    public Task Dispatch<TEvent>(TEvent @event, CancellationToken ct = default)
    where TEvent : EventBase;
}
