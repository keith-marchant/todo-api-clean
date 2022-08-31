using TodoApp.Application.Entities;
using TodoApp.Application.Enums;
using TodoApp.Application.Pagination;

namespace TodoApp.Application.Interfaces
{
    /// <summary>
    /// Item repository to access items from storage.
    /// </summary>
    public interface IItemRepository
    {
        /// <summary>
        /// Search for items meeting specific criteria.
        /// </summary>
        /// <param name="offset">The searchoffset.</param>
        /// <param name="limit">The result limit.</param>
        /// <param name="status">The status to search for.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<Page<TodoItem>> GetTodoItems(int offset, int limit, TodoItemStatusEnum? status, CancellationToken cancellationToken);
        /// <summary>
        /// Get a specific item.
        /// </summary>
        /// <param name="itemId">The item to search for.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<TodoItem?> GetTodoItem(int itemId, CancellationToken cancellationToken);
        /// <summary>
        /// Update an item.
        /// </summary>
        /// <param name="item">The item and properties to update.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task UpdateTodoItem(TodoItem item, CancellationToken cancellationToken);
        /// <summary>
        /// Create a new todo item.
        /// </summary>
        /// <param name="title">The item title.</param>
        /// <param name="description">The item description.</param>
        /// <param name="dueDate">The item due date.</param>
        /// <param name="status">The item status.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<TodoItem> CreateTodoItem(string title, string? description, DateTime? dueDate, TodoItemStatusEnum status, CancellationToken cancellationToken);
    }
}
