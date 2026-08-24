using Fund.Core;
using Fund.Core.Api;
using Fund.Core.Entities;
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
        var dbPath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "app.db");

        var services = new ServiceCollection();

        services.AddFundCore().AddInfrastructure();

        services.GetIntegrationBuilder().AddSqlite(opt =>
        {

            var connectionString = $"Data Source={dbPath}";

            opt.ConnectionString = connectionString;
        });

        using (var sp = services.BuildServiceProvider())
        {
            try
            {
                var initializer = sp.GetRequiredService<DatabaseInitializer>();
                initializer.Initialize();

                var equipmentService = sp.GetRequiredService<ICommandService<Equipment>>();
                var productService = sp.GetRequiredService<ICommandService<Product>>();
                var ownerService = sp.GetRequiredService<ICommandService<Owner>>();

                await equipmentService.AddAsync(new Equipment
                {
                    Name = "equip",
                    TypeId = "equip",
                    SerialNumber = "equip",
                    InventoryNumber = "equip",
                    Status = "equip",
                    Description = "equip",
                    ConfigurationUnitId = "equip"
                });

                await productService.AddAsync(new Product
                {
                    Name = "prod",
                    Description = "prod"
                });

                await ownerService.AddAsync(new Owner
                {
                    Name = "owner",
                    TypeId = "owner",
                    Description = "owner"
                });
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{exception.Message}\n");
                Assert.Fail(exception.StackTrace);
            }
            finally
            {
                File.Delete(dbPath);
            }
        }
    }
}