using TodoApp.Application.Entities;
using TodoApp.Application.Enums;
using TodoApp.Application.Pagination;

namespace TodoApp.Application.Interfaces
{
    public interface IItemRepository
    {
        Task<Page<TodoItem>> GetTodoItems(int offset, int limit, TodoItemStatusEnum? status, CancellationToken cancellationToken);
        Task<TodoItem?> GetTodoItem(int itemId, CancellationToken cancellationToken);
        Task UpdateTodoItem(TodoItem item, CancellationToken cancellationToken);
        Task<TodoItem> CreateTodoItem(string title, string? description, DateTime? dueDate, TodoItemStatusEnum status, CancellationToken cancellationToken);
    }
}
