using FluentValidation;

namespace TodoApp.Application.Items.Commands.UpdateItem
{
    public class UpdateItemCommandValidator : AbstractValidator<UpdateItemCommand>
    {
        public UpdateItemCommandValidator()
        {
            RuleFor(x => x.Title).MaximumLength(100).MinimumLength(1);
            RuleFor(x => x.ItemId).GreaterThan(0);
        }
    }
}
