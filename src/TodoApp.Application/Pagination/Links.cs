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
        public Links(Uri self)
        {
            Self = self;
        }

        /// <summary>
        /// Gets a URI link to the current page.
        /// </summary>
        public Uri Self { get; }
        /// <summary>
        /// Gets a URI link to the next page.
        /// </summary>
        public Uri? Next { get; set; }
        /// <summary>
        /// Gets a URI link to the previous page.
        /// </summary>
        public Uri? Previous { get; set; }
    }
}
