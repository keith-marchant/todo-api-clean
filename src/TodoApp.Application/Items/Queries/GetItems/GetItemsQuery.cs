using TodoApp.Application.Enums;
using TodoApp.Application.Items.Dtos;
using TodoApp.Application.Pagination;

namespace TodoApp.Application.Items.Queries.GetItems
{
    public class GetItemsQuery : PaginatedQuery<TodoItemDto>
    {
        public GetItemsQuery(TodoItemStatusEnum? status, int? limit, int? offset)
        {
            Status = status;
            Limit = limit ?? Limit;
            Offset = offset ?? Offset;
        }

        public TodoItemStatusEnum? Status { get; }
    }
}
