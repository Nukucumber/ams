using IntegrationModule.TgBot.Options;

using Microsoft.Extensions.Options;

using Telegram.Bot;

namespace IntegrationModule.TgBot;

internal sealed class TelegramBotClientProvider : IDisposable
{
    public ITelegramBotClient Client => _client;

    private readonly IOptionsMonitor<TgBotOptions> _options;
    private readonly TelegramBotClientFactory _factory;

    private ITelegramBotClient _client;
    private readonly IDisposable? _optionsSubscription;


    public TelegramBotClientProvider(
        IOptionsMonitor<TgBotOptions> options,
        TelegramBotClientFactory factory)
    {
        _options = options;
        _factory = factory;

        _client = _factory.Create(_options.CurrentValue);

        _optionsSubscription = _options.OnChange(options =>
        {
            var oldClient = _client;
            _client = _factory.Create(options);

            if (oldClient is IDisposable disposable)
                disposable.Dispose();
        });
    }

    public void Dispose()
    {
        _optionsSubscription?.Dispose();

        if (_client is IDisposable disposable)
            disposable.Dispose();
    }
}