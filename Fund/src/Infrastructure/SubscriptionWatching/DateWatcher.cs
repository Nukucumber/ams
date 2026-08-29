using Fund.Core.Application.Abstractions;
using Fund.Core.Application.Events;
using Fund.Core.Domain.Entities;
using Fund.Infrastructure.Implements;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Fund.Infrastructure.SubscriptionWatching;


internal class DateWatcher
{
    private readonly EventPublisher _eventPublisher;
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<DateWatcher> _logger;
    private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

    private DateTimeOffset? _nearestWatchingDate;
    private Timer? _timer;

    public DateWatcher(EventPublisher eventPublisher, IServiceScopeFactory scopeFactory, ILogger<DateWatcher> logger)
    {
        _eventPublisher = eventPublisher;
        _scopeFactory = scopeFactory;
        _logger = logger;
    }


    public async Task StartWatch(ProductSubscription subscription, CancellationToken ct = default)
    {
        await _semaphore.WaitAsync(ct);
        try
        {
            if (_nearestWatchingDate is not null &&
            _nearestWatchingDate <= subscription.ExpiresAt)
            {
                return;
            }

            Reset();

            _nearestWatchingDate = subscription.ExpiresAt;
            var delay = _nearestWatchingDate - DateTimeOffset.Now;
            var delayMilliseconds = (long)delay.Value.TotalMilliseconds;

            if (delayMilliseconds <= 0)
            {
                _ = ProductSubscriptionExpireEventPublish(subscription);
                return;
            }

            _timer = new Timer(
                callback: OnTimerComplite,
                state: subscription,
                dueTime: delayMilliseconds,
                period: Timeout.Infinite);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Failed to start subscription date watcher");
            Reset();

            await EventPublish(new NearestSubscriptionWatchRequestedEvent());
        }
        finally
        {
            _semaphore.Release();
        }
    }


    public void Reset()
    {
        _timer?.Dispose();
        _timer = null;
        _nearestWatchingDate = null;
    }


    private void OnTimerComplite(object? state)
    {
        if (state is not ProductSubscription subscription)
        {
            return;
        }

        _ = ProductSubscriptionExpireEventPublish(subscription);
    }

    private async Task ProductSubscriptionExpireEventPublish(ProductSubscription productSubscription)
    {
        try
        {
            await EventPublish(
                new ProductSubscriptionExpireEvent(
                    productSubscription
                ));
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Failed on subscription date watcher timer complite");
            
            await EventPublish(new NearestSubscriptionWatchRequestedEvent());
        }
    }

    private async Task EventPublish(EventBase @event)
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            var eventCollector = scope.ServiceProvider.GetRequiredService<EventCollector>();

            eventCollector.Collect(@event);
            await _eventPublisher.Publish(eventCollector);
        }
    }
}
