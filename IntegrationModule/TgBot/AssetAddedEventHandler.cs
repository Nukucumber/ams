using Fund.Core.Events;
using Fund.Infrastructure.Ports;

namespace IntegrationModule.TgBot;

public class AssetAddedEventHandler : IEventHandler<AssetAddedEvent>
{
    public Task Handle(AssetAddedEvent @event, CancellationToken ct = default)
    {
        Console.WriteLine(@event.OwnerId);
        return Task.CompletedTask;
    }
}