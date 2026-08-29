namespace Fund.Core.Domain.Abstractions;

public abstract class FundEntityBase
{
    public string Id { get; init; } = Guid.NewGuid().ToString("N");
}