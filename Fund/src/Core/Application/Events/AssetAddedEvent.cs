using Fund.Core.Application.Abstractions;
using Fund.Core.Application.Ports;
using Fund.Core.Domain.Entities;

namespace Fund.Core.Application.Events;

public record AssetAddedEvent(
    Asset Asset,
    Owner Owner
) : EventBase
{
    public override async Task DispatchAsync(IEventDispatcher dispatcher, CancellationToken ct = default)
    {
        await dispatcher.Dispatch(this, ct);
    }
}