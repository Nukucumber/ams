namespace IntegrationModule.TgBot.Options;

public sealed class TgBotOptions
{
    public required string BotToken { get; set; }
    public required string[] Chats { get; set; }
    public ProxyOptions? ProxyOptions { get; set; }
}