using Fund.Core.Domain.Abstractions;

namespace Fund.Core.Domain.Entities;

public sealed class SoftwareInstallation : FundEntityBase
{
    public required string SoftwareId { get; init; }
    public DateTimeOffset InstalledAt { get; init; }
    public DateTimeOffset? RemovedAt { get; set; }
    public required string ConfigurationUnitId { get; set; }
}