using Fund.Core.Domain.Abstractions;

namespace Fund.Core.Domain.Types;


public class SoftwareType : FundEntityBase
{
    public required string Name { get; set; }
}
