using TodoApp.Application.Enums;

namespace TodoApp.Application.Entities
{
    public class TodoItem
    {
        public int ItemId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public TodoItemStatusEnum Status { get; set; }
    }
}
