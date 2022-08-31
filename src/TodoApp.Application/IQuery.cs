using MediatR;

namespace TodoApp.Application
{
    /// <summary>
    /// Mediatr <see cref="IRequest{TResponse}"/> wrapper for methods without side effects.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}
