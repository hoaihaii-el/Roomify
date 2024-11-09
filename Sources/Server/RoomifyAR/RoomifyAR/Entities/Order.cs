namespace RoomifyAR.Entities
{
    public class Order : BaseEntityAudit
    {
        public int UserId { get; set; }
        public float TotalPrice { get; set; }
        public string Status { get; set; } = "";
    }
}
