using Fund.Core.Application.Abstractions;
using Fund.Infrastructure.SubscriptionWatching;
using IntegrationModule.TgBot.Options;
using Microsoft.Extensions.Options;
using Telegram.Bot;

namespace IntegrationModule.TgBot;

internal class ProductSubscriptionExpireEventHandler : IEventHandler<ProductSubscriptionExpireEvent>
{
    private readonly TelegramBotClientProvider _botClientProvider;
    private readonly IOptionsMonitor<TgBotOptions> _options;

    public ProductSubscriptionExpireEventHandler(TelegramBotClientProvider botClientProvider, IOptionsMonitor<TgBotOptions> options)
    {
        _botClientProvider = botClientProvider;
        _options = options;
    }


    public async Task Handle(ProductSubscriptionExpireEvent @event, CancellationToken ct = default)
    {
        var botClient = _botClientProvider.Client;
        var chats = _options.CurrentValue.Chats;

        foreach (var chat in chats)
        {
            await botClient.SendMessage(
                chatId: chat,
                text: @event.ProductSubscription.Id,
                cancellationToken: ct
            );
        }
    }
}