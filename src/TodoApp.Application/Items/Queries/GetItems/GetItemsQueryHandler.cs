using AutoMapper;
using TodoApp.Application.Interfaces;
using TodoApp.Application.Items.Dtos;
using TodoApp.Application.Pagination;

namespace TodoApp.Application.Items.Queries.GetItems
{
    public class GetItemsQueryHandler : IQueryHandler<GetItemsQuery, PaginatedResult<TodoItemDto>>
    {
        private readonly IItemRepository _repository;
        private readonly IMapper _mapper;

        public GetItemsQueryHandler(IItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<TodoItemDto>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
        {
            var results = await _repository.GetTodoItems(request.Offset, request.Limit, request.Status, cancellationToken);

            var mappedResults = _mapper.Map<List<TodoItemDto>>(results.Results);

            return new PaginatedResult<TodoItemDto> { Total = results.Total, Results = mappedResults };
        }
    }
}
