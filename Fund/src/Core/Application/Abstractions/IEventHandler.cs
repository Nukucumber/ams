namespace Fund.Core.Application.Abstractions;

public interface IEventHandler<in TEvent>
    where TEvent : EventBase
{
    Task Handle(TEvent @event, CancellationToken ct = default);
}