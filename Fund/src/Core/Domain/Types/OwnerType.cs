using Fund.Core.Domain.Abstractions;

namespace Fund.Core.Domain.Types;

public sealed class OwnerType : FundEntityBase
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}