using Fund.Core.Application.Abstractions;
using Fund.Core.Application.Events;
using Fund.Core.Application.Ports;
using Fund.Infrastructure.Abstractions;

namespace Fund.Infrastructure.Implements;

internal sealed class TransactionalMediator : ICommandMediator
{
    private readonly ICommandMediator _innerMediator;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEventPublisher _eventPublisher;
    private readonly EventCollector _eventCollector;


    public TransactionalMediator(
        ICommandMediator innerMediator,
        IUnitOfWork unitOfWork,
        IEventPublisher eventPublisher,
        EventCollector eventCollector)
    {
        _innerMediator = innerMediator;
        _unitOfWork = unitOfWork;
        _eventPublisher = eventPublisher;
        _eventCollector = eventCollector;
    }


    public async Task Send<TCommand>(TCommand command, CancellationToken ct = default) where TCommand : ICommand
    {
        await _unitOfWork.BeginTransactionAsync(ct);
        try
        {
            await _innerMediator.Send(command, ct);
            await _unitOfWork.CommitAsync(ct);
            await _eventPublisher.Publish(_eventCollector, ct);
        }
        catch
        {
            await _unitOfWork.RollbackAsync(ct);
            throw;
        }
    }

    public async Task<TResponse?> Send<TCommand, TResponse>(TCommand command, CancellationToken ct = default) where TCommand : ICommand<TResponse>
    {
        await _unitOfWork.BeginTransactionAsync(ct);
        try
        {
            var response = await _innerMediator.Send<TCommand, TResponse>(command, ct);
            await _unitOfWork.CommitAsync(ct);
            await _eventPublisher.Publish(_eventCollector, ct);

            return response;
        }
        catch
        {
            await _unitOfWork.RollbackAsync(ct);
            throw;
        }
    }
}