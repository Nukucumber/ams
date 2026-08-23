namespace Fund.Core.Entities;

public sealed class EquipmentTransfer
{
    public required string Id { get; init; }
    public required string EquipmentId { get; init; }

    public string? FromUserId { get; init; }
    public string? ToUserId { get; init; }

    public DateTimeOffset OccurredAt { get; init; }
    public string? Comment { get; init; }
}