using TodoApp.Application.Items.Dtos;

namespace TodoApp.Application.Items.Commands.CreateItem
{
    public class CreateItemCommand : ICommand<TodoItemDto>
    {
        public CreateItemCommand(string title, string? description, DateTime? dueDate)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
        }

        public string Title { get; }
        public string? Description { get; }
        public DateTime? DueDate { get; }
    }
}
