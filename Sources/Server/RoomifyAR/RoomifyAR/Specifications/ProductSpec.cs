namespace RoomifyAR.Specifications
{
    public class ProductSpec
    {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;

        private int _PageSize = 8;
        public int PageSize
        {
            get => _PageSize;
            set => _PageSize = value > MaxPageSize ? MaxPageSize : value;
        }
        public string? SortCol { get; set; }
        public string? SortType { get; set; }

        private string? _Search;
        public string Search
        {
            get => _Search ?? "";
            set => _Search = value.ToLower();
        }
    }
}
