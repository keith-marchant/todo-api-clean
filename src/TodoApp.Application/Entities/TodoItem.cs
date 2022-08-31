using TodoApp.Application.Enums;

namespace TodoApp.Application.Entities
{
    /// <summary>
    /// Object represeting a Todo item to be acted upon by business logic.
    /// </summary>
    public class TodoItem
    {
        /// <summary>
        /// Gets or sets the ItemId.
        /// </summary>
        public int ItemId { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Gets or sets the DueDate.
        /// </summary>
        public DateTime? DueDate { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public TodoItemStatusEnum Status { get; set; }
    }
}
