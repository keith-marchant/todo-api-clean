using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using TodoApp.Application.Pagination;
using Microsoft.AspNetCore.WebUtilities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TodoApp.Api.Controllers
{
    /// <summary>
    /// Base API controller providing Mediator and pagination helpers.
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {
        /// <summary>
        /// Provides quick access without dependency injection to <see cref="IMediator"/>.
        /// </summary>
        protected IMediator Mediator => HttpContext.RequestServices.GetRequiredService<IMediator>();
        protected virtual IUrlHelper UrlHelper => Url;

        /// <summary>
        /// Create a pagination response for a given action.
        /// </summary>
        /// <typeparam name="T1">The type of the query.</typeparam>
        /// <typeparam name="T2">The type of the response.</typeparam>
        /// <param name="actionName">The action to paginate.</param>
        /// <param name="query">The mediator query to paginate.</param>
        /// <param name="result">The response DTO.</param>
        /// <returns>Link to the current page.</returns>
        /// <exception cref="ArgumentNullException">Throws if query or result are null.</exception>
        protected Links CreatePaginationLinks<T1, T2>(string actionName, PaginatedQuery<T1> query, PaginatedResult<T2> result)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            var routeLink = UrlHelper.Action(actionName) ?? "";

            var links = new Links(GetLink(routeLink, query.Offset, query.Limit));

            // next
            if (query.Offset + query.Limit < result.Total)
            {
                var offset = query.Offset + query.Limit;

                links.Next = GetLink(routeLink, offset, query.Limit);
            }

            // previous
            if (query.Offset > 0)
            {
                var offset = query.Offset <= query.Limit ? 0 : query.Offset - query.Limit;

                links.Previous = GetLink(routeLink, offset, query.Limit);
            }

            return links;
        }

        private static string GetLink(string url, int offset, int limit)
        {
            var queryMap = new Dictionary<string, string?>
            {
                    { "offset", offset.ToString() },
                    { "limit", limit.ToString() }
                };

            return QueryHelpers.AddQueryString(url, queryMap);
        }
    }
}
