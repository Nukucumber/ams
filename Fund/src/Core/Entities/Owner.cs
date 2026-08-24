using Fund.Core.Abstractions;

namespace Fund.Core.Entities;

public sealed class Owner : IFundEntity
{
    public string Id { get; init; } = Guid.NewGuid().ToString("N");
    public required string Name { get; set; }
    public required string TypeId { get; init; }
    public string? Description { get; set; }
}