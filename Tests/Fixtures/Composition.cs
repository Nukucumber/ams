using Fund.Core;
using Fund.Infrastructure;
using IntegrationModule;
using IntegrationModule.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cucumber.Tests.Fixtures;

public static class Composition
{
    public static IServiceCollection DependencyRegistry(this IServiceCollection services, IConfiguration configuration)
    {
        var dbPath = configuration["DbPath"]!;

        services.AddFundCore().AddInfrastructure();


        services.GetIntegrationBuilder()
                .AddSqlite(opt =>
                {
                    opt.DbPath = dbPath;
                });

        return services;
    }
}