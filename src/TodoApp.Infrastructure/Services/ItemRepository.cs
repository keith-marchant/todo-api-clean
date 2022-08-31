using TodoApp.Application.Entities;
using TodoApp.Application.Enums;
using TodoApp.Application.Interfaces;

namespace TodoApp.Infrastructure.Services
{
    internal class ItemRepository : IItemRepository
    {
        public Task<TodoItem> CreateTodoItem(string title, string? description, DateTime? dueDate, TodoItemStatusEnum status, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<TodoItem> GetTodoItem(int itemId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TodoItem>> GetTodoItems(int? offset, int? limit, TodoItemStatusEnum? status, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTodoItem(TodoItem item, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
