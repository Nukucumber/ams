using Fund.Infrastructure;
using Host.Api;
using IntegrationModule;
using IntegrationModule.Sqlite;
using Photino.NET;

namespace Host;


public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateSlimBuilder(args);
        builder.Services.ConfigureHttpJsonOptions(options =>
        {
            options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
        });
        builder.Services.AddOpenApi();
        builder.Services.AddFund();
        builder.Services.GetIntegrationBuilder()
            .AddSqlite(cfg =>
        {
        });


        var app = builder.Build();
        using (var scope = app.Services.CreateScope())
        {
            var initializer =
                scope.ServiceProvider
                    .GetRequiredService<DatabaseInitializer>();

            initializer.Initialize();
        }
        app.MapApi();
        _ = app.RunAsync();


        var window = new PhotinoWindow()
            .SetTitle("Мое AOT-приложение")
            .SetUseOsDefaultSize(false)
            .SetSize(800, 600)
            .Center()
            .Load(Path.Combine(AppContext.BaseDirectory, "wwwroot", "index.html"));
        window.WaitForClose();
    }
}