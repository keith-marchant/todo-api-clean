namespace TodoApp.Application.Pagination
{
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
