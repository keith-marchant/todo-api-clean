namespace TodoApp.Application.Pagination
{
    /// <summary>
    /// Base DTO for paginated API requests.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class PaginatedQuery<T> : IQuery<PaginatedResult<T>>
    {
        private int? _limit;

        /// <summary>
        /// Gets or sets the maximum number of records to return.
        /// </summary>
        public int Limit
        {
            // global defaults and limits for pagination result counts
            get
            {
                return _limit ?? 10;
            }
            set
            {
                if (value < 1)
                {
                    _limit = 10;
                }
                else if (value > 100)
                {
                    _limit = 100;
                }
                else
                {
                    _limit = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the offset from 0 of the request.
        /// </summary>
        public int Offset { get; set; }
    }
}
