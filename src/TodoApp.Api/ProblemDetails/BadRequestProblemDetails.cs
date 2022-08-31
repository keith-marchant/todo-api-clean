using FluentValidation;
using TodoApp.Application.Exceptions;

namespace TodoApp.Api.ProblemDetails
{
    /// <summary>
    /// A machine-readable format for specifying errors in HTTP API responses based on https://tools.ietf.org/html/rfc7807.
    /// Used for client 400 errors.
    /// </summary>
    public class BadRequestProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        /// <summary>
        /// Create a new <see cref="BadRequestProblemDetails"/>.
        /// </summary>
        /// <param name="ex">The exception to convert.</param>
        public BadRequestProblemDetails(ValidationException ex)
        {
            Status = StatusCodes.Status400BadRequest;
            Title = "Bad Request";
            Detail = string.Join(";", ex.Errors);
            Type = "https://httpstatuses.com/400";
        }

        /// <summary>
        /// Create a new <see cref="BadRequestProblemDetails"/>.
        /// </summary>
        /// <param name="ex">The exception to convert.</param>
        public BadRequestProblemDetails(ArgumentOutOfRangeException ex)
        {
            Status = StatusCodes.Status400BadRequest;
            Title = "Bad Request";
            Detail = ex?.Message;
            Type = "https://httpstatuses.com/400";
        }

        /// <summary>
        /// Create a new <see cref="BadRequestProblemDetails"/>.
        /// </summary>
        /// <param name="ex">The exception to convert.</param>
        public BadRequestProblemDetails(InvalidArgumentException ex)
        {
            Status = StatusCodes.Status400BadRequest;
            Title = "Bad Request";
            Detail = ex?.Message;
            Type = "https://httpstatuses.com/400";
        }
    }
}
