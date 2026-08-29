using Fund.Core.Domain.Abstractions;
using Fund.Core.Domain.Statuses;

namespace Fund.Core.Domain.Entities;


public sealed class Equipment : FundEntityBase
{
    public required string Name { get; set; }
    public required string TypeId { get; init; }
    public string? SerialNumber { get; set; }
    public string? InventoryNumber { get; set; }
    public string Status { get; set; } = EquipmentStatus.Active.ToString();
    public string? Description { get; set; }
    public required string ConfigurationUnitId { get; set; }
}