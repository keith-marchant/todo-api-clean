using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using TodoApp.Application.Pagination;

namespace TodoApp.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {
        protected IMediator Mediator => HttpContext.RequestServices.GetRequiredService<IMediator>();
        protected virtual IUrlHelper UrlHelper => Url;

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

            var links = new Links(new Uri(UrlHelper.Action(actionName, query) ?? HttpContext.Request.GetEncodedUrl()));

            // next
            if (query.Offset + query.Limit < result.Total)
            {
                query.Offset += query.Limit;

                var next = UrlHelper.Action(actionName, query);
                
                if (!string.IsNullOrEmpty(next))
                {
                    links.Next = new Uri(next);
                }

                query.Offset -= query.Limit;
            }

            // previous
            if (query.Offset > 0)
            {
                if (query.Offset <= query.Limit)
                {
                    query.Offset = 0;
                }
                else
                {
                    query.Offset -= query.Limit;
                }

                var previous = UrlHelper.Action(actionName, query);

                if (!string.IsNullOrEmpty(previous))
                {
                    links.Previous = new Uri(previous);
                }
            }

            return links;
        }
    }
}
