using Fund.Core.Abstractions;


namespace Fund.Core.Entities;

public sealed class Asset : FundEntityBase
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required string OwnerId { get; set; }
}