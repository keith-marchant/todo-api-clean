using TodoApp.Application.Exceptions;

namespace TodoApp.Api.ProblemDetails
{
    /// <summary>
    /// A machine-readable format for specifying errors in HTTP API responses based on https://tools.ietf.org/html/rfc7807.
    /// Used for Client 429 errors.
    /// </summary>
    public class RateLimitedProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        /// <summary>
        /// Create a new <see cref="RateLimitedProblemDetails"/>.
        /// </summary>
        /// <param name="ex">The exception to convert.</param>
        public RateLimitedProblemDetails(RateLimitedException ex)
        {
            Status = StatusCodes.Status429TooManyRequests;
            Title = "Too Many Requests";
            Detail = ex?.Message;
            Type = "https://httpstatuses.com/429";
        }
    }
}
