using System.Text.Json.Serialization;
using TodoApp.Application.Enums;

namespace TodoApp.Application.Items.Commands.UpdateItem
{
    public class UpdateItemCommand : ICommand
    {
        public UpdateItemCommand(string title, string? description, DateTime? dueDate, TodoItemStatusEnum status)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Status = status;
        }

        public int ItemId { get; set; }
        public string Title { get; }
        public string? Description { get; }
        public DateTime? DueDate { get; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TodoItemStatusEnum Status { get; }
    }
}
