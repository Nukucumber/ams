using Fund.Core.Abstractions;

namespace Fund.Core.Entities;

public sealed class Product : FundEntityBase
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}