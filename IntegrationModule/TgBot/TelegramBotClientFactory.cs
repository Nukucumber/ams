using System.Net;
using IntegrationModule.TgBot.Options;
using Telegram.Bot;

namespace IntegrationModule.TgBot;

public class TelegramBotClientFactory
{
    public ITelegramBotClient Create(TgBotOptions options)
    {
        return new TelegramBotClient(
            options.BotToken,
            CreateHttpClient(options));
    }

    private HttpClient CreateHttpClient(TgBotOptions options)
    {
        var proxyOptions = options.ProxyOptions;

        if (proxyOptions is null ||
            string.IsNullOrWhiteSpace(proxyOptions.ProxyAddress) ||
            !proxyOptions.UseProxy)
            return new HttpClient();

        var proxy = new WebProxy(proxyOptions.ProxyAddress)
        {
            Credentials = new NetworkCredential(
                proxyOptions.Credential?.Username,
                proxyOptions.Credential?.Password)
        };

        var handler = new HttpClientHandler
        {
            Proxy = proxy
        };

        return new HttpClient(handler);
    }
}