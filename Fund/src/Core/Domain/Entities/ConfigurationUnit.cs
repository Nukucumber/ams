using Fund.Core.Domain.Abstractions;


namespace Fund.Core.Domain.Entities;

public class ConfigurationUnit: FundEntityBase
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required string AssetId { get; set; }
}