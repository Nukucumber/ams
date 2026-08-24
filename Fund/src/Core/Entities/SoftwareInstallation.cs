
using Fund.Core.Abstractions;

namespace Fund.Core.Entities;

public sealed class SoftwareInstallation : IFundEntity
{
    public required string Id { get; init; }
    public required string SoftwareId { get; init; }
    public DateTimeOffset InstalledAt { get; init; }
    public DateTimeOffset? RemovedAt { get; set; }
    public required string ConfigurationUnitId { get; set; }
}