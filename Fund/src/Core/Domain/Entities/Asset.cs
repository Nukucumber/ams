using Fund.Core.Domain.Abstractions;


namespace Fund.Core.Domain.Entities;

public sealed class Asset : FundEntityBase
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required string OwnerId { get; set; }
}