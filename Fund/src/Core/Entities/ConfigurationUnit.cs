using Fund.Core.Abstractions;


namespace Fund.Core.Entities;

public class ConfigurationUnit: FundEntityBase
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required string AssetId { get; set; }
}