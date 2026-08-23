using Fund.Core.Abstractions;


namespace Fund.Core.Entities;


public sealed class Equipment : IFundEntity
{
    public string Id { get; init; } = Guid.NewGuid().ToString("N");
    public required string Name { get; set; }
    public required string TypeId { get; init; }
    public string? SerialNumber { get; set; }
    public string? InventoryNumber { get; set; }
    public required string Status { get; set; }
    public string? Description { get; set; }
    public required string UserId { get; set; }
}

public class ConfigurationUnit: IFundEntity
{
    
}





public sealed class Asset : IFundEntity
{
    public string Id { get; init; } = Guid.NewGuid().ToString("N");
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required string UserId { get; set; }
}