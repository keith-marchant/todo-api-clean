namespace TodoApp.Api.ProblemDetails
{
    /// <summary>
    /// A machine-readable format for specifying errors in HTTP API responses based on https://tools.ietf.org/html/rfc7807.
    /// Used for Server 500 errors.
    /// </summary>
    public class UnhandledExceptionProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        /// <summary>
        /// Create a new <see cref="UnhandledExceptionProblemDetails"/>.
        /// </summary>
        /// <param name="ex">The exception to convert.</param>
        public UnhandledExceptionProblemDetails(Exception ex)
        {
            Status = StatusCodes.Status500InternalServerError;
            Title = "Internal Server Error";
            Detail = ex.Message;
            Type = "https://httpstatuses.com/500";
        }
    }
}
