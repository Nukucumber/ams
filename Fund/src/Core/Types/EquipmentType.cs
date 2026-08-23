using Fund.Core.Abstractions;

namespace Fund.Core.Types;

public class EquipmentType : IFundEntity
{
    public required string Id { get; init; }
    public required string Name { get; set; }
}
