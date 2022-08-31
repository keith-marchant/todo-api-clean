using FluentValidation;

namespace TodoApp.Application.Items.Queries.GetItemById
{
    public class GetItemByIdQueryValidator : AbstractValidator<GetItemByIdQuery>
    {
        public GetItemByIdQueryValidator()
        {
            RuleFor(x => x.ItemId).GreaterThan(0);
        }
    }
}
