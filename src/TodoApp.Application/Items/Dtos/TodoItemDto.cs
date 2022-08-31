using System.Text.Json.Serialization;
using TodoApp.Application.Entities;
using TodoApp.Application.Enums;
using TodoApp.Application.Mapping;

namespace TodoApp.Application.Items.Dtos
{
    public class TodoItemDto : IMapFrom<TodoItem>
    {
        public int ItemId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TodoItemStatusEnum Status { get; set; }
    }
}
