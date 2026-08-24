using Fund.Core.Abstractions;

namespace Fund.Core.Entities;

public sealed class Product : IFundEntity
{
    public string Id { get; init; } = Guid.NewGuid().ToString("N");
    public required string Name { get; set; }
    public string? Description { get; set; }
}