
using Fund.Core.Abstractions;

namespace Fund.Core.Entities;

public sealed class Software : IFundEntity
{
    public required string Id { get; init; }
    public required string Name { get; set; }
    public string? Version { get; set; }
    public required string TypeId { get; init; }
    public required string UserId { get; set; }
}
