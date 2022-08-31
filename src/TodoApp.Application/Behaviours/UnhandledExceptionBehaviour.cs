using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using TodoApp.Application.Exceptions;

namespace TodoApp.Application.Behaviours
{
    /// <summary>
    /// Mediatr behaviour that logs unhandled exceptions occuring during the handler or pipeline.
    /// </summary>
    /// <typeparam name="TRequest">The request type.</typeparam>
    /// <typeparam name="TResponse">The response type.</typeparam>
    public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<TRequest> _logger;

        /// <summary>
        /// Create a new <see cref="UnhandledExceptionBehaviour{TRequest,TResponse}"/>.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <exception cref="ArgumentNullException">Thrown if any parameter is null.</exception>
        public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Catch unhandled exceptions and log them.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="next">The next handler in the pipeline.</param>
        /// <returns>The response.</returns>
        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            when (ex is UnauthorisedException or ForbiddenException or ValidationException or NotFoundException or RateLimitedException)
            {
                LogException(ex, LogLevel.Warning, request);
                throw;
            }
            catch (Exception ex)
            {
                LogException(ex, LogLevel.Error, request);
                throw;
            }
        }

        private void LogException(Exception ex, LogLevel level, TRequest request)
        {
            var requestName = typeof(TRequest).Name;

            _logger.Log(
                level,
                ex,
                "Request Error: {ExceptionType} for Request {Name} {@Request}",
                ex.GetType().Name,
                requestName,
                request);
        }
    }
}
