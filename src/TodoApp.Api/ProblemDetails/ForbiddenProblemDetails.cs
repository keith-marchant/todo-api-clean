using TodoApp.Application.Exceptions;

namespace TodoApp.Api.ProblemDetails
{
    /// <summary>
    /// A machine-readable format for specifying errors in HTTP API responses based on https://tools.ietf.org/html/rfc7807.
    /// Used for client 403 errors.
    /// </summary>
    public class ForbiddenProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        /// <summary>
        /// Create a new <see cref="ForbiddenProblemDetails"/>.
        /// </summary>
        /// <param name="ex">The exception to convert.</param>
        public ForbiddenProblemDetails(ForbiddenException ex)
        {
            Status = StatusCodes.Status403Forbidden;
            Title = "Forbidden";
            Detail = ex?.Message;
            Type = "https://httpstatuses.com/403";
        }
    }
}
