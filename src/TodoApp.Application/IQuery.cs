using MediatR;

namespace TodoApp.Application
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}
