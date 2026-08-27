using Cucumber.Tests.Fixtures;

namespace Cucumber.Tests.Integration;

[Collection("IntegrationTests")]
public class EntityTests
{
    private readonly AppFixture _app;

    public EntityTests(AppFixture app)
    {
        _app = app;
    }


    [Fact]
    public async Task ScopeLifetimeTest()
    {
        
    }
}