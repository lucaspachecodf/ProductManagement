namespace AutoGlass.ProductManagement.Application.Models
{
    public class PaginatedResult<T>
    {
        public IEnumerable<T> Items { get; }
        public int TotalItems { get; }
        public int PageNumber { get; }
        public int PageSize { get; }

        public PaginatedResult(IEnumerable<T> items, int totalItems, int pageNumber, int pageSize)
        {
            Items = items;
            TotalItems = totalItems;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
