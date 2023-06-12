using System.Collections;

namespace Application.Pagination
{
    public class PaginatedData<T>
    {
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public IList<T> Data { get; set; }
    }
}