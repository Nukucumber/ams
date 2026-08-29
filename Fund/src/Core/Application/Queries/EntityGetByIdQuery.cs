using Fund.Core.Application.Abstractions;
using Fund.Core.Domain.Abstractions;

namespace Fund.Core.Application.Queries;

internal record EntityGetByIdQuery<TEntity>(string EntityId) : IQuery<TEntity?>
where TEntity : FundEntityBase;