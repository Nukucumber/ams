using Fund.Core.Abstractions;

namespace Fund.Infrastructure.Ports;

public interface IEventHandler<in TEvent>
    where TEvent : EventBase
{
    Task Handle(TEvent @event, CancellationToken ct = default);
}