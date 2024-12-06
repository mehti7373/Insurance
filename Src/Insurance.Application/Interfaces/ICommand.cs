namespace Insurance.Application.Interfaces;

public interface ICommand<out TResult>
{
}
public interface ICommandHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
    Task<TResponse> Handle(TCommand command, CancellationToken cancellationToken);
}
