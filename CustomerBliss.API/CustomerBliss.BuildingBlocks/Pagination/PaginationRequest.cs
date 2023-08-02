namespace CustomerBliss.BuildingBlocks.Pagination
{
    public class PaginationRequest<TData>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public TData Data { get; set; }
    }
}