using Fund.Core.Application.Abstractions;
using Fund.Core.Application.Events;
using IntegrationModule.TgBot.Options;
using Microsoft.Extensions.Options;
using Telegram.Bot;

namespace IntegrationModule.TgBot;

internal class AssetAddedEventHandler : IEventHandler<AssetAddedEvent>
{
    private readonly TelegramBotClientProvider _telegramBotClientProvider;
    private readonly IOptionsMonitor<TgBotOptions> _options;

    public AssetAddedEventHandler(TelegramBotClientProvider telegramBotClientProvider, IOptionsMonitor<TgBotOptions> options)
    {
        _telegramBotClientProvider = telegramBotClientProvider;
        _options = options;
    }


    public async Task Handle(AssetAddedEvent @event, CancellationToken ct = default)
    {
        var chats = _options.CurrentValue.Chats;

        foreach (var chat in chats)
        {
            await _telegramBotClientProvider.Client.SendMessage(
                chatId: chat,
                text: "",
                cancellationToken: ct
            );
        }
    }
}