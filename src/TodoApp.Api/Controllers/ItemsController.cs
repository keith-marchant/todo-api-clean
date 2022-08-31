using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.Enums;
using TodoApp.Application.Items.Dtos;
using TodoApp.Application.Items.Queries.GetItems;
using TodoApp.Application.Pagination;

namespace TodoApp.Api.Controllers
{
    public class ItemsController : ApiController
    {
        [ProducesResponseType(typeof(PaginatedResult<TodoItemDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<PaginatedResult<TodoItemDto>>> GetAll(
            [FromQuery] TodoItemStatusEnum? status,
            [FromQuery] int? limit,
            [FromQuery]int? offset,
            CancellationToken cancellationToken)
        {
            var query = new GetItemsQuery(status, limit, offset);

            var result = await Mediator.Send(query, cancellationToken);
            result.Links = CreatePaginationLinks(nameof(GetAll), query, result);

            return Ok(result);
        }
    }
}
