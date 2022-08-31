namespace TodoApp.Application.Exceptions
{
    /// <summary>
    /// An error generated when attempting to access a resource too frequently.
    /// </summary>
    public class RateLimitedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RateLimitedException"/> class.</summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public RateLimitedException(Uri instance, string message)
            : base(message)
        {
            Instance = instance;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RateLimitedException"/> class.</summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public RateLimitedException(Uri instance, string message, Exception innerException)
            : base(message, innerException)
        {
            Instance= instance;
        }

        /// <summary>
        /// The <see cref="Uri"/> of the resource that has been rate limited.
        /// </summary>
        public Uri Instance { get; }
    }
}
