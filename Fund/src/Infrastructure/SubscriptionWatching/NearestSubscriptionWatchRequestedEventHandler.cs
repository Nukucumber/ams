using Fund.Core.Application.Abstractions;

namespace Fund.Infrastructure.SubscriptionWatching;

internal class NearestSubscriptionWatchRequestedEventHandler : IEventHandler<NearestSubscriptionWatchRequestedEvent>
{
    private readonly DateWatcher _dateWatcher;
    private readonly INearestProductSubscriptionRepository _repository;

    public NearestSubscriptionWatchRequestedEventHandler(
        DateWatcher dateWatcher,
        INearestProductSubscriptionRepository repository)
    {
        _dateWatcher = dateWatcher;
        _repository = repository;
    }


    public async Task Handle(NearestSubscriptionWatchRequestedEvent @event, CancellationToken ct)
    {
        var subscription = await _repository.GetNearest(ct);
        if (subscription == null)
        {
            return;
        }
        await _dateWatcher.StartWatch(subscription, ct);
    }
}
