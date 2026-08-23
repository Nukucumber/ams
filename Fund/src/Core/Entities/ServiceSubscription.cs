using Fund.Core.Abstractions;

namespace Fund.Core.Entities;

public sealed class ServiceSubscription : IFundEntity
{
    public required string Id { get; init; }
    public required string ServiceId { get; init; }
    public DateTimeOffset StartedAt { get; init; }
    public DateTimeOffset? ExpiresAt { get; set; }
    public int? Seats { get; set; }
    public required string Status { get; set; }
    public required string UserId { get; set; }
}