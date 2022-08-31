using TodoApp.Application.Items.Dtos;

namespace TodoApp.Application.Items.Queries.GetItemById
{
    public class GetItemByIdQuery : IQuery<TodoItemDto>
    {
        public GetItemByIdQuery(int itemId)
        {
            ItemId = itemId;
        }

        public int ItemId { get; }
    }
}
