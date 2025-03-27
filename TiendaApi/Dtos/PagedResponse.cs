namespace TiendaApi.Dtos
{
    public class PagedResponse<T>
    {
        public string Message { get; set; }
        public List<T> Data { get; set; }
        public int TotalItems { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

        public PagedResponse(string message, List<T> data, int totalItems, int page, int pageSize)
        {
            Message = message;
            Data = data;
            TotalItems = totalItems;
            Page = page;
            PageSize = pageSize;
        }
    }
}
