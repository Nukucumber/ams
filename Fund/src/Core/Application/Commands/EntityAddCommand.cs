using Fund.Core.Application.Abstractions;
using Fund.Core.Domain.Abstractions;

namespace Fund.Core.Application.Commands;

internal record EntityAddCommand<TEntity>(TEntity Entity) : ICommand
where TEntity : FundEntityBase;