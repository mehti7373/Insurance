namespace Insurance.Application.Interfaces;

public interface IQuery<out TResult> 
{
}
public interface IQueryHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
    Task<TResponse> Handle(TQuery query, CancellationToken cancellationToken);
}