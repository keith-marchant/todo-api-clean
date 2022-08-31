using AutoMapper;
using TodoApp.Application.Exceptions;
using TodoApp.Application.Interfaces;
using TodoApp.Application.Items.Dtos;

namespace TodoApp.Application.Items.Queries.GetItemById
{
    public class GetItemByIdQueryHandler : IQueryHandler<GetItemByIdQuery, TodoItemDto>
    {
        private readonly IItemRepository _repository;
        private readonly IMapper _mapper;

        public GetItemByIdQueryHandler(IItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TodoItemDto> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
        {
            var item = await _repository.GetTodoItem(request.ItemId, cancellationToken);

            if (item == null)
            {
                throw new NotFoundException($"Could not locate item {request.ItemId}.");
            }

            return _mapper.Map<TodoItemDto>(item);
        }
    }
}
