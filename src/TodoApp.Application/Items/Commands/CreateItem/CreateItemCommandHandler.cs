using AutoMapper;
using TodoApp.Application.Interfaces;
using TodoApp.Application.Items.Dtos;

namespace TodoApp.Application.Items.Commands.CreateItem
{
    public class CreateItemCommandHandler : ICommandHandler<CreateItemCommand, TodoItemDto>
    {
        private readonly IItemRepository _repository;
        private readonly IMapper _mapper;

        public CreateItemCommandHandler(IItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TodoItemDto> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _repository.CreateTodoItem(
                request.Title, request.Description, request.DueDate, Enums.TodoItemStatusEnum.Incomplete, cancellationToken);
            return _mapper.Map<TodoItemDto>(item);
        }
    }
}
