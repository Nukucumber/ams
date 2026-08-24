using Host.Api;
using IntegrationModule.Sqlite;
using Fund.Infrastructure;
using IntegrationModule;
using Fund.Core;

public static class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateSlimBuilder(args);

        builder.Services.ConfigureHttpJsonOptions(options =>
        {
            options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
        });

        builder.Services.AddOpenApi();

        builder.Services.AddFundCore()
                        .AddInfrastructure();
        builder.Services.GetIntegrationBuilder()
                        .AddSqlite(cfg =>
                        {

                        })
                        // .AddTgBot();
                        ;

        var app = builder.Build();
        app.UseDefaultFiles();
        app.UseStaticFiles();

        app.MapFallbackToFile("index.html");

        using (var scope = app.Services.CreateScope())
        {
            var initializer =
                scope.ServiceProvider
                    .GetRequiredService<DatabaseInitializer>();

            initializer.Initialize();
        }
        app.MapApi();

        app.Run();
    }
}