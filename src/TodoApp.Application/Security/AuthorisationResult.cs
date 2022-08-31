namespace TodoApp.Application.Security
{
    /// <summary>
    /// Track a user's authorisation status when making requests.
    /// </summary>
    public class AuthorisationResult
    {
        private AuthorisationResult(bool isAuthorised, string? failureMessage)
        {
            IsAuthorised = isAuthorised;
            FailureMessage = failureMessage;
        }

        /// <summary>
        /// Gets whether the user is authorised.
        /// </summary>
        public bool IsAuthorised { get; }
        /// <summary>
        /// Gets or sets the reason authorisation has failed.
        /// </summary>
        public string? FailureMessage { get; set; }

        /// <summary>
        /// Get a default authorisation failure.
        /// </summary>
        /// <returns>An <see cref="AuthorisationResult"/> where authorisation has failed.</returns>
        public static AuthorisationResult Fail()
        {
            return new AuthorisationResult(false, null);
        }

        /// <summary>
        /// Get an authorisation failure with a custom failure message.
        /// </summary>
        /// <param name="failureMessage">The authorisation failure message.</param>
        /// <returns>An <see cref="AuthorisationResult"/> where authorisation has failed.</returns>
        public static AuthorisationResult Fail(string failureMessage)
        {
            return new AuthorisationResult(false, failureMessage);
        }

        /// <summary>
        /// Get a default authorisation success.
        /// </summary>
        /// <returns>An <see cref="AuthorisationResult"/> where authorisation has succeeded.</returns>
        public static AuthorisationResult Succeed()
        {
            return new AuthorisationResult(true, null);
        }
    }
}
