namespace TodoApp.Application.Exceptions
{
    /// <summary>
    /// An error generated when attempting to access a resource that requires authentication without providing valid credentials.
    /// </summary>
    public class UnauthorisedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnauthorisedException"/> class.</summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public UnauthorisedException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnauthorisedException"/> class.</summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public UnauthorisedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
