using MediatR;
using TodoApp.Application.Exceptions;
using TodoApp.Application.Interfaces;

namespace TodoApp.Application.Items.Commands.UpdateItem
{
    public class UpdateItemCommandHandler : ICommandHandler<UpdateItemCommand>
    {
        private readonly IItemRepository _repository;

        public UpdateItemCommandHandler(IItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _repository.GetTodoItem(request.ItemId, cancellationToken);

            if (item is null)
            {
                throw new NotFoundException($"Could not locate item {request.ItemId}.");
            }

            item.Title = request.Title;
            item.Description = request.Description;
            item.DueDate = request.DueDate;
            item.Status = request.Status;

            await _repository.UpdateTodoItem(item, cancellationToken);

            return Unit.Value;
        }
    }
}
