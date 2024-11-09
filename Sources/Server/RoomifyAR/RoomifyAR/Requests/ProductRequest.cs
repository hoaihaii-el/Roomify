namespace RoomifyAR.Requests
{
    public class ProductRequest
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public float Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public string Model3dUrl { get; set; } = "";
        public List<string> Medias { get; set; } = [];
    }
}
