using Fund.Core.Abstractions;


namespace Fund.Core.Entities;


public sealed class Equipment : FundEntityBase
{
    public required string Name { get; set; }
    public required string TypeId { get; init; }
    public string? SerialNumber { get; set; }
    public string? InventoryNumber { get; set; }
    public required string Status { get; set; }
    public string? Description { get; set; }
    public required string ConfigurationUnitId { get; set; }
}