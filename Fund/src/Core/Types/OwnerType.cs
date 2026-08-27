using Fund.Core.Abstractions;

namespace Fund.Core.Types;

public sealed class OwnerType : FundEntityBase
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}