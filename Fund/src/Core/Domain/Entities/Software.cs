using Fund.Core.Domain.Abstractions;

namespace Fund.Core.Domain.Entities;

public sealed class Software : FundEntityBase
{
    public required string Name { get; set; }
    public string? Version { get; set; }
    public required string TypeId { get; init; }
}
