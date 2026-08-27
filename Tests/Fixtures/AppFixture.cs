using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cucumber.Tests.Fixtures;

public sealed class AppFixture : IAsyncLifetime
{
    public ServiceProvider ServiceProvider { get; private set; } = null!;
    private string _dbPath;

    public AppFixture()
    {
        _dbPath = Path.Combine(
            Path.GetTempPath(),
            "tests",
            "test.db");        
    }


    public async Task InitializeAsync()
    {
        Directory.CreateDirectory(Path.GetDirectoryName(_dbPath)!);


        var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

        configuration["DbPath"] = _dbPath;


        ServiceCollection services = new();

        services.DependencyRegistry(configuration);

        ServiceProvider = services.BuildServiceProvider();

        ServiceProvider.DbInit();
    }

    public async Task DisposeAsync()
    {
        await ServiceProvider.DisposeAsync();
        Directory.Delete(Path.GetDirectoryName(_dbPath)!, true);
    }
}