
using Fund.Core.Abstractions;

namespace Fund.Core.Entities;

public sealed class SoftwareInstallation : IFundEntity
{
    public required string Id { get; init; }

    public required string SoftwareId { get; init; }

    public required string EquipmentId { get; init; }

    public string? Version { get; set; }

    public DateTimeOffset InstalledAt { get; init; }

    public DateTimeOffset? RemovedAt { get; set; }
}