namespace RoomifyAR.Entities
{
    public class ProductMedia : BaseEntity
    {
        public int ProductId { get; set; }
        public int Order { get; set; }
        public string Url { get; set; } = "";
        public Product? Product { get; set; }
    }
}
