using Fund.Core.Application.Abstractions;
using Fund.Core.Application.Ports;
using Fund.Core.Domain.Entities;

namespace Fund.Infrastructure.SubscriptionWatching;

public record ProductSubscriptionExpireEvent(
    ProductSubscription ProductSubscription
) : EventBase
{
    public override async Task DispatchAsync(IEventDispatcher dispatcher, CancellationToken ct = default)
    {
        await dispatcher.Dispatch(this, ct);
    }
}