using Fund.Core.Domain.Abstractions;

namespace Fund.Core.Domain.Types;

public class EquipmentType : FundEntityBase
{
    public required string Name { get; set; }
}
