using MediatR;

namespace TodoApp.Application
{
    /// <summary>
    /// Mediatr <see cref="IRequestHandler{TRequest,TResponse}"/> wrapper for methods without side effects.
    /// </summary>
    /// <typeparam name="TQuery">The type of the query.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IQueryHandler<in TQuery, TResult> :
        IRequestHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
    }
}
