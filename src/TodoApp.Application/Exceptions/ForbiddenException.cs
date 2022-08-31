namespace TodoApp.Application.Exceptions
{
    /// <summary>
    /// An error generated when attempting to access a resource you are not authorised to view, or perform an action blocked by an object's current state.
    /// </summary>
    public class ForbiddenException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ForbiddenException"/> class.</summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public ForbiddenException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ForbiddenException"/> class.</summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public ForbiddenException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
