using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace TodoApp.Application.Behaviours
{
    /// <summary>
    /// Mediatr behaviour that logs each request.
    /// </summary>
    /// <typeparam name="TRequest">The request type.</typeparam>
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
    {
        private readonly ILogger _logger;

        /// <summary>
        /// Create a new <see cref="RequestLogger{TRequest}"/>.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="userService">The user service.</param>
        /// <exception cref="ArgumentNullException">Thrown if any parameter is null.</exception>
        public RequestLogger(ILogger<TRequest> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Log the request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task handle for the log process.</returns>
        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;

            _logger.LogInformation(
                "Request: {Name} {@Request}",
                requestName,
                request);

            return Task.CompletedTask;
        }
    }
}
