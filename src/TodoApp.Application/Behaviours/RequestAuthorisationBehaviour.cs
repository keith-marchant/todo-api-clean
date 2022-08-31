using MediatR;
using TodoApp.Application.Exceptions;
using TodoApp.Application.Security;

namespace TodoApp.Application.Behaviours
{
    /// <summary>
    /// Mediatr behaviour that triggers registered authorisers during the pipeline.
    /// </summary>
    /// <typeparam name="TRequest">The request type.</typeparam>
    /// <typeparam name="TResponse">The response type.</typeparam>
    public class RequestAuthorisationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IAuthoriser<TRequest>> _authorisers;

        /// <summary>
        /// Create a new <see cref="RequestAuthorisationBehaviour{TRequest,TResponse}"/>.
        /// </summary>
        /// <param name="authorisers">List of all authorisers.</param>
        public RequestAuthorisationBehaviour(IEnumerable<IAuthoriser<TRequest>> authorisers)
        {
            _authorisers = authorisers;
        }

        /// <summary>
        /// Execute authorisation checks.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="next">The next handler in the pipeline.</param>
        /// <returns>The response.</returns>
        /// <exception cref="ArgumentNullException">Thrown if any parameter is null.</exception>
        /// <exception cref="ForbiddenException">Thrown if authorisation fails.</exception>
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (next == null)
            {
                throw new ArgumentNullException(nameof(next));
            }

            foreach (var authorizer in _authorisers)
            {
                var result = await authorizer.AuthoriseAsync(request, cancellationToken);
                if (!result.IsAuthorised)
                {
                    throw new ForbiddenException(result.FailureMessage ?? $"Access to {typeof(TRequest).Name} forbidden.");
                }
            }

            return await next();
        }
    }
}
