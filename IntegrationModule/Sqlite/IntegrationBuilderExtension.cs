using Fund.Infrastructure.Ports;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationModule.Sqlite;

public static class IntegrationBuilderExtensionSqlite
{
    public static IntegrationBuilder AddSqlite(this IntegrationBuilder builder, Action<SqliteOption> configure)
    {
        builder.Services.Configure(configure);

        builder.Services.AddSingleton<SqliteConnectionFactory>();
        
        builder.Services.AddSingleton<IDbConnectionFactory, DbConnectionFactoryAdapter>();

        builder.Services.AddTransient<DatabaseInitializer>();

        return builder;
    }
}