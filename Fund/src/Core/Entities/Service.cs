using Fund.Core.Abstractions;

namespace Fund.Core.Entities;

public sealed class Service : IFundEntity
{
    public required string Id { get; init; }
    public required string Name { get; set; }
    public required string TypeId { get; init; }
    public string? Description { get; set; }
    public required string UserId { get; set; }
}