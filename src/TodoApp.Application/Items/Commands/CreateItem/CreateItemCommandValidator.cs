using FluentValidation;

namespace TodoApp.Application.Items.Commands.CreateItem
{
    public class CreateItemCommandValidator : AbstractValidator<CreateItemCommand>
    {
        public CreateItemCommandValidator()
        {
            RuleFor(x => x.Title).MaximumLength(100).MinimumLength(1);
        }
    }
}
