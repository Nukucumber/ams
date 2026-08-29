using Fund.Core.Domain.Entities;

namespace Fund.Infrastructure.SubscriptionWatching;

internal interface INearestProductSubscriptionRepository
{
    Task<ProductSubscription?> GetNearest(CancellationToken ct = default);
}
