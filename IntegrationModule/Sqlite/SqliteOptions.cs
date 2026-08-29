namespace IntegrationModule.Sqlite;

public sealed class SqliteOptions
{
    public string DbPath { get; set; } = "app.db";

    internal string ConnectionString => $"Data Source={DbPath}";
}