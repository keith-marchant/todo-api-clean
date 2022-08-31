using Microsoft.AspNetCore.Mvc;
using TodoApp.Api.ProblemDetails;
using TodoApp.Application.Enums;
using TodoApp.Application.Items.Dtos;
using TodoApp.Application.Items.Queries.GetItemById;
using TodoApp.Application.Items.Queries.GetItems;
using TodoApp.Application.Pagination;

namespace TodoApp.Api.Controllers
{
    /// <summary>
    /// Controller for accessing todo items.
    /// </summary>
    public class ItemsController : ApiController
    {
        /// <summary>
        /// Search for a <see cref="TodoItemDto"/>.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <param name="limit">The query limit.</param>
        /// <param name="offset">The query offset.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(PaginatedResult<TodoItemDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(UnhandledExceptionProblemDetails), StatusCodes.Status500InternalServerError)]
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

        [ProducesResponseType(typeof(PaginatedResult<TodoItemDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(UnhandledExceptionProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("{itemId}")]
        public async Task<ActionResult<TodoItemDto>> GetById([FromRoute]int itemId, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetItemByIdQuery(itemId), cancellationToken));
        }
    }
}
