using Fund.Core.Abstractions;
using Fund.Core.Ports;

namespace Fund.Core.Events;

public record AssetAddedEvent(
    string Id,
    string Name,
    string OwnerId
) : EventBase
{
    public override async Task DispatchAsync(IEventDispatcher dispatcher, CancellationToken ct = default)
    {
        await dispatcher.Dispatch(this, ct);
    }
}