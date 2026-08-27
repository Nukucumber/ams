
using Fund.Core.Abstractions;

namespace Fund.Core.Entities;

public sealed class Software : FundEntityBase
{
    public required string Name { get; set; }
    public string? Version { get; set; }
    public required string TypeId { get; init; }
}
