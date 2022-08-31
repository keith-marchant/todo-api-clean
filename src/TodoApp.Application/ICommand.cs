using MediatR;

namespace TodoApp.Application
{
    /// <summary>
    /// Mediatr <see cref="IRequest{TResponse}"/> wrapper for requests with side effects.
    /// </summary>
    public interface ICommand : IRequest
    {
    }

    /// <summary>
    /// Mediatr <see cref="IRequest{TResponse}"/> wrapper for requests with side effects.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public interface ICommand<out TResult> : IRequest<TResult>
    {
    }
}
