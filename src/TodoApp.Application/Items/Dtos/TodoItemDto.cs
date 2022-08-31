using System.Text.Json.Serialization;
using TodoApp.Application.Entities;
using TodoApp.Application.Enums;
using TodoApp.Application.Mapping;

namespace TodoApp.Application.Items.Dtos
{
    /// <summary>
    /// DTO for todo items.
    /// </summary>
    public class TodoItemDto : IMapFrom<TodoItem>
    {
        /// <summary>
        /// Gets or sets the item Id.
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
        /// Gets or sets the due date.
        /// </summary>
        public DateTime? DueDate { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TodoItemStatusEnum Status { get; set; }
    }
}
