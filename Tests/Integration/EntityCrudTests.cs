using Cucumber.Tests.Fixtures;
using Fund.Core.Application.Api;
using Fund.Core.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Cucumber.Tests.Integration;

[Collection("IntegrationTests")]
public sealed class EntityCrudTests
{
    private readonly AppFixture _app;

    public EntityCrudTests(AppFixture app)
    {
        _app = app;
    }

    [Fact]
    public async Task Add_ShouldPersistEntity()
    {
        var entityService = GetEntityService();


        var equipment = CreateEquipment();

        await entityService.AddAsync(equipment);

        var result =
            await entityService.GetByIdAsync(equipment.Id);

        Assert.NotNull(result);
        Assert.Equal(equipment.Id, result.Id);
        Assert.Equal(equipment.Name, result.Name);
        Assert.Equal(equipment.TypeId, result.TypeId);
        Assert.Equal(equipment.SerialNumber, result.SerialNumber);
        Assert.Equal(equipment.InventoryNumber, result.InventoryNumber);
        Assert.Equal(equipment.Description, result.Description);
        Assert.Equal(
            equipment.ConfigurationUnitId,
            result.ConfigurationUnitId);
    }

    [Fact]
    public async Task Update_ShouldPersistChanges()
    {
        var entityService = GetEntityService();

        var equipment = CreateEquipment();

        await entityService.AddAsync(equipment);

        equipment.Name = "new_eq_name";

        await entityService.UpdateAsync(equipment);

        var result =
            await entityService.GetByIdAsync(equipment.Id);

        Assert.NotNull(result);
        Assert.Equal("new_eq_name", result.Name);
    }

    [Fact]
    public async Task Delete_ShouldRemoveEntity()
    {
        var entityService = GetEntityService();


        var equipment = CreateEquipment();

        await entityService.AddAsync(equipment);
        await entityService.DeleteAsync(equipment.Id);

        var result =
            await entityService.GetByIdAsync(equipment.Id);

        Assert.Null(result);
    }

    [Fact]
    public async Task GetAll_ShouldReturnAllEntities()
    {
        var entityService = GetEntityService();
        var entitiesOnStart =
            await entityService.GetAllAsync().ToListAsync();

        var startCount = entitiesOnStart.Count();


        const int count = 5;

        for (var i = 0; i < count; i++)
        {
            await entityService.AddAsync(
                CreateEquipment(i));
        }

        var result =
            await entityService.GetAllAsync().ToListAsync();

        Assert.Equal(startCount + count, result.Count);
    }

    private ICommonEntityService<Equipment> GetEntityService()
    {
        return _app.ServiceProvider
            .GetRequiredService<ICommonEntityService<Equipment>>();
    }


    private static Equipment CreateEquipment(int index = 0)
    {
        return new Equipment
        {
            Name = $"eq_name_{index}",
            TypeId = $"eq_type_{index}",
            SerialNumber = $"eq_sn_{index}",
            InventoryNumber = $"eq_in_{index}",
            Description = string.Empty,
            ConfigurationUnitId = $"configuration_{index}",
        };
    }
}