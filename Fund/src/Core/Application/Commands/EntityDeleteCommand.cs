using Fund.Core.Application.Abstractions;
using Fund.Core.Domain.Abstractions;

namespace Fund.Core.Application.Commands;

internal record EntityDeleteCommand<TEntity>(string EntityId) : ICommand
where TEntity : FundEntityBase;
