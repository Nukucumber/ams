using Fund.Core.Application.Abstractions;

namespace Fund.Core.Application.Events;

public sealed class EventCollector
{
    private List<EventBase> _events { get; } = [];

    public IReadOnlyList<EventBase> Events => _events;

    public void Collect(EventBase @event)
    {
        _events.Add(@event);
    }

    public void Free()
    {
        _events.Clear();
    }
}