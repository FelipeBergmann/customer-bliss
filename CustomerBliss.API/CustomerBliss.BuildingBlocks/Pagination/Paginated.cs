namespace CustomerBliss.BuildingBlocks.Pagination
{
    public class Paginated<TData>
    {
        public int Page { get; set; }
        public int TotalRegisterQty { get; set; }
        public TData Data { get; set; }
    }
}