using TodoApp.Application.Exceptions;

namespace TodoApp.Api.ProblemDetails
{
    /// <summary>
    /// A machine-readable format for specifying errors in HTTP API responses based on https://tools.ietf.org/html/rfc7807.
    /// Used for Client 401 errors.
    /// </summary>
    public class UnauthorisedProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        /// <summary>
        /// Create a new <see cref="UnauthorisedProblemDetails"/>.
        /// </summary>
        /// <param name="ex">The exception to convert.</param>
        public UnauthorisedProblemDetails(UnauthorisedException ex)
        {
            Status = StatusCodes.Status401Unauthorized;
            Title = "Unauthorised";
            Detail = ex?.Message;
            Type = "https://httpstatuses.com/401";
        }
    }
}
