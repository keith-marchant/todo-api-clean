namespace TodoApp.Application.Pagination
{
    /// <summary>
    /// Base DTO for paginated responses. 
    /// </summary>
    /// <typeparam name="T">The type of the results.</typeparam>
    public class PaginatedResult<T>
    {
        /// <summary>
        /// Gets or sets the previous, current, and next page results.
        /// </summary>
        public Links? Links { get; set; }
        /// <summary>
        /// Gets or sets the total records in the result set.
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// Gets or sets the result set.
        /// </summary>
        public IEnumerable<T>? Results { get; set; }
    }
}
