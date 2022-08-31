namespace TodoApp.Application.Pagination
{
    /// <summary>
    /// Internal class to transfer paginated query results.
    /// </summary>
    /// <typeparam name="T">The type of the query results.</typeparam>
    public class Page<T>
    {
        /// <summary>
        /// Construct a <see cref="Page"/> object.
        /// </summary>
        /// <param name="total">The total available results.</param>
        /// <param name="results">The results for this page.</param>
        public Page(int total, IEnumerable<T> results)
        {
            Total = total;
            Results = results;
        }
        
        /// <summary>
        /// Gets or sets the total records in the result set.
        /// </summary>
        public int Total { get; }
        /// <summary>
        /// Gets or sets the result set.
        /// </summary>
        public IEnumerable<T> Results { get; }
    }
}
