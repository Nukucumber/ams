using Fund.Core.Abstractions;


namespace Fund.Core.Entities;

public class ConfigurationUnit: IFundEntity
{
    public string Id { get; init; } = Guid.NewGuid().ToString("N");
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required string AssetId { get; set; }
}