namespace TodoApp.Application.Pagination
{
    /// <summary>
    /// DTO for links in paginated API results.
    /// </summary>
    public class Links
    {
        /// <summary>
        /// Create a new <see cref="Links"/> object.
        /// </summary>
        /// <param name="self">The current URL.</param>
        public Links(string self)
        {
            Self = self;
        }

        /// <summary>
        /// Gets a URI link to the current page.
        /// </summary>
        public string Self { get; }
        /// <summary>
        /// Gets a URI link to the next page.
        /// </summary>
        public string? Next { get; set; }
        /// <summary>
        /// Gets a URI link to the previous page.
        /// </summary>
        public string? Previous { get; set; }
    }
}
