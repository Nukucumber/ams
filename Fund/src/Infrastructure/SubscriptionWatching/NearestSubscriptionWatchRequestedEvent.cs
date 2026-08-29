using Fund.Core.Application.Abstractions;
using Fund.Core.Application.Ports;

namespace Fund.Infrastructure.SubscriptionWatching;

internal record NearestSubscriptionWatchRequestedEvent : EventBase
{
    public override async Task DispatchAsync(IEventDispatcher dispatcher, CancellationToken ct = default)
    {
        await dispatcher.Dispatch(this, ct);
    }
}
