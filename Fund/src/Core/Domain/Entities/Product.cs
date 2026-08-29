using Fund.Core.Domain.Abstractions;

namespace Fund.Core.Domain.Entities;

public sealed class Product : FundEntityBase
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}