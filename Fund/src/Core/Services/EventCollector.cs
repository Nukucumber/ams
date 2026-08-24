using Fund.Core.Abstractions;

namespace Fund.Core.Services;

public class EventCollector
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