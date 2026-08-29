using Fund.Core.Domain.Abstractions;

namespace Fund.Core.Domain.Entities;

public sealed class ProductSubscription : FundEntityBase
{
    public required string ProductId { get; init; }
    public DateTimeOffset StartedAt { get; init; }
    public DateTimeOffset ExpiresAt { get; set; }
    public required string Status { get; set; }
    public required string ConfigurationUnitId { get; set; }
}