namespace IntegrationModule.TgBot.Options;

public sealed class ProxyOptions
{
    public string ProxyAddress { get; set; } = string.Empty;
    public bool UseProxy { get; set; } = false;

    public Credential? Credential { get; set; }
}
