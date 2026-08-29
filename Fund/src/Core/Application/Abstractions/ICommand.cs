namespace Fund.Core.Application.Abstractions;

public interface ICommand;

public interface ICommand<TResponse>: ICommand;