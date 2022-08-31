using MediatR;

namespace TodoApp.Application
{
    /// <summary>
    /// Mediatr <see cref="IRequestHandler{TRequest,TResponse}"/> wrapper for requests with side effects.
    /// </summary>
    /// <typeparam name="TCommand">The type of the command.</typeparam>
    public interface ICommandHandler<in TCommand> :
        IRequestHandler<TCommand>
        where TCommand : ICommand
    {
    }

    /// <summary>
    /// Mediatr <see cref="IRequestHandler{TRequest,TResponse}"/> wrapper for requests with side effects.
    /// </summary>
    /// <typeparam name="TCommand">The type of the command.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface ICommandHandler<in TCommand, TResult> :
        IRequestHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
    {
    }
}
