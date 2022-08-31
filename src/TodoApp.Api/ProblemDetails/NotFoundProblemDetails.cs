using TodoApp.Application.Exceptions;

namespace TodoApp.Api.ProblemDetails
{
    /// <summary>
    /// A machine-readable format for specifying errors in HTTP API responses based on https://tools.ietf.org/html/rfc7807.
    /// Used for client 404 errors.
    /// </summary>
    public class NotFoundProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        /// <summary>
        /// Create a new <see cref="NotFoundProblemDetails"/>.
        /// </summary>
        /// <param name="ex">The exception to convert.</param>
        public NotFoundProblemDetails(NotFoundException ex)
        {
            Status = StatusCodes.Status404NotFound;
            Title = "Not Found";
            Detail = ex.Message;
            Type = "https://httpstatuses.com/404";
        }
    }
}
