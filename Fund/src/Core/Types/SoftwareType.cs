using Fund.Core.Abstractions;

namespace Fund.Core.Types;


public class SoftwareType : IFundEntity
{
    public required string Id { get; init; }
    public required string Name { get; set; }
}
