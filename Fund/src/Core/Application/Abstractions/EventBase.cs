using Fund.Core.Application.Ports;

namespace Fund.Core.Application.Abstractions;

public abstract record EventBase
{
    public abstract Task DispatchAsync(IEventDispatcher dispatcher, CancellationToken ct = default);
}