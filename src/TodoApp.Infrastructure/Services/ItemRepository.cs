using Microsoft.EntityFrameworkCore;
using TodoApp.Application.Entities;
using TodoApp.Application.Enums;
using TodoApp.Application.Interfaces;
using TodoApp.Application.Pagination;
using TodoApp.Infrastructure.Persistence;

namespace TodoApp.Infrastructure.Services
{
    internal class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _dbContext;

        public ItemRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<TodoItem> CreateTodoItem(string title, string? description, DateTime? dueDate, TodoItemStatusEnum status, CancellationToken cancellationToken)
        {
            var item = new TodoItem { Title = title, Description = description, DueDate = dueDate };
            _dbContext.TodoItems.Add(item);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return item;
        }

        public async Task<TodoItem?> GetTodoItem(int itemId, CancellationToken cancellationToken)
        {
            return await _dbContext.TodoItems.FirstOrDefaultAsync(t => t.ItemId == itemId, cancellationToken);
        }

        public async Task<Page<TodoItem>> GetTodoItems(int offset, int limit, TodoItemStatusEnum? status, CancellationToken cancellationToken)
        {
            var query = _dbContext.TodoItems.AsQueryable();

            if (status is not null)
            {
                query = query.Where(t => t.Status == status);
            }

            var totalCount = await query.CountAsync(cancellationToken);
            if (totalCount == 0)
            {
                return new Page<TodoItem>(0, new List<TodoItem>());
            }

            var results = await query.Skip(offset).Take(limit).ToListAsync(cancellationToken);

            return new Page<TodoItem>(totalCount, results);
        }

        public async Task UpdateTodoItem(TodoItem item, CancellationToken cancellationToken)
        {
            _dbContext.TodoItems.Update(item);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
