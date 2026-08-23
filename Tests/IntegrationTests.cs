using Fund.Core.Api;
using Fund.Infrastructure;
using IntegrationModule;
using IntegrationModule.Sqlite;
using Microsoft.Extensions.DependencyInjection;

namespace Cucumber.Tests;

public class IntegrationTests
{
    [Fact]
    public async Task EquipmentServiceTests()
    {
        var services = new ServiceCollection();

        services.AddFund();

        services.GetIntegrationBuilder().AddSqlite(opt =>
        {
            // var dbPath = Path.Combine(
            //     AppContext.BaseDirectory,
            //     "app.db");

            // Console.WriteLine(dbPath);


            // var connectionString = $"Data Source={dbPath}";

            // opt.ConnectionString = connectionString;
        });

        using (var sp = services.BuildServiceProvider())
        {
            try
            {
                var initializer = sp.GetRequiredService<DatabaseInitializer>();
                initializer.Initialize();

                var equipmentService = sp.GetRequiredService<IEquipmentService>();
                await equipmentService.Test();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{exception.Message}\n");
                Assert.Fail(exception.StackTrace);
            }
        }
    }
}