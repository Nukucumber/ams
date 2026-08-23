using Fund.Core.Abstractions;

namespace Fund.Core.Types;

public sealed class UserType : IFundEntity
{
    public required string Id { get; init; }

    public required string Name { get; set; }

    public string? Description { get; set; }
}