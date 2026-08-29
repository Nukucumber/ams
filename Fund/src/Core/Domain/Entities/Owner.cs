using Fund.Core.Domain.Abstractions;

namespace Fund.Core.Domain.Entities;

public sealed class Owner : FundEntityBase
{
    public required string Name { get; set; }
    public required string TypeId { get; init; }
    public string? Description { get; set; }
}