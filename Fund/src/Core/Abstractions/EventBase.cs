using Fund.Core.Ports;

namespace Fund.Core.Abstractions;

public abstract record EventBase
{
    public abstract Task DispatchAsync(IEventDispatcher dispatcher, CancellationToken ct = default);
}