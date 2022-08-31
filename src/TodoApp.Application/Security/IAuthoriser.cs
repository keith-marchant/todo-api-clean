namespace TodoApp.Application.Security
{
    /// <summary>
    /// Helper used in the Mediatr pipelines to authorise requests.
    /// </summary>
    /// <typeparam name="T">The request type to authorise.</typeparam>
    public interface IAuthoriser<T>
    {
        /// <summary>
        /// Authorise the current identity's ability to access a resource encapsulated by T.
        /// </summary>
        /// <param name="instance">The resource to access.</param>
        /// <param name="cancellation">The cancellation token.</param>
        /// <returns>The <see cref="AuthorisationResult"/> denoting access permissions.</returns>
        Task<AuthorisationResult> AuthoriseAsync(T instance, CancellationToken cancellation = default);
    }
}
