using TodoApp.Application.Exceptions;

namespace TodoApp.Api.ProblemDetails
{
    /// <summary>
    /// A machine-readable format for specifying errors in HTTP API responses based on https://tools.ietf.org/html/rfc7807.
    /// Used for client 409 errors.
    /// </summary>
    public class ConflictProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        /// <summary>
        /// Create a new <see cref="ConflictProblemDetails"/>.
        /// </summary>
        /// <param name="ex">The exception to convert.</param>
        public ConflictProblemDetails(ConflictException ex)
        {
            Status = StatusCodes.Status409Conflict;
            Title = "Conflict";
            Detail = ex?.Message;
            Type = "https://httpstatuses.com/409";
        }
    }
}
